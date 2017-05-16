using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
namespace Web
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

    }

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var u = CoreRequest<User>("http://localhost:3274/Member.svc/User/1", null, "GET");
            if(u!=null){
                Response.Write(u.Name);
            }
        }

        private   T CoreRequest<T>(string url, object objdata, string mt)
        {
            T obj = default(T);
            Stream dataStream = null;
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myHttpWebRequest.Timeout = 50000;
                myHttpWebRequest.Method = mt;
                myHttpWebRequest.ContentType = "application/json; charset=utf-8";
                //myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                if (objdata != null)
                {
                    using (StreamWriter writer = new StreamWriter(myHttpWebRequest.GetRequestStream()))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(objdata.GetType());
                        MemoryStream ms = new MemoryStream();
                        serializer.WriteObject(ms, objdata);
                        ms.Position = 0;
                        writer.Write(Encoding.UTF8.GetString(ms.ToArray()).ToCharArray());
                        writer.Close();
                    }
                }


                WebResponse wp = myHttpWebRequest.GetResponse();
                using (HttpWebResponse response = wp as HttpWebResponse)
                {
                    if (response.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        dataStream = response.GetResponseStream();
                        StreamReader r = new StreamReader(dataStream, Encoding.UTF8);
                        string StrRetP = r.ReadToEnd();

                        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(StrRetP));
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                        obj = (T)serializer.ReadObject(ms);
                        ms.Close();

                    }

                }

            }
            catch (WebException)
            {

            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
            finally
            {
                if (null != dataStream) dataStream.Close();
            }
            return obj;
        }

    }
}
