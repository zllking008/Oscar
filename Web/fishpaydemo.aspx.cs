using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace Web
{
    public partial class fishpaydemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var time= UnixTimestampToDateTime(1382694957);
            Response.Write(time.ToString());
            //Response.Write(DateTimeToUnixTimestamp(DateTime.Parse("2013/10/25 9:55:57 ")));
        }

        /// <summary>
        /// 日期转换成unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        /// <summary>
        /// unix时间戳转换成日期
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（秒）</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTime.Now.Kind);
            return start.AddSeconds(timestamp);
        }

        protected void btn_sub_Click(object sender, EventArgs e)
        {
            string pkey = tb_pkey.Text;
            string platform = tb_platform.Text;
            string gkey = tb_gkey.Text;
            string skey = tb_skey.Text;


            string uid = System.Web.HttpUtility.UrlDecode(tb_uid.Text);
            string role_id = "";
            string role_name = "";
            string order_id = tb_order_id.Text;
            string coins = tb_coins.Text;
            string moneys = tb_moneys.Text;
            
            string mark = "#";

            //标准时间戳，从柏林时间1970开始算
            DateTime timeStamp = new DateTime(1970, 1, 1);
            long time = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000;

            string data = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", uid, platform, gkey, skey, time, order_id, coins, moneys, mark, pkey);
            string sign = GetMD5(data);
            string strParams = string.Format("gkey={0}&skey={1}&platform={2}&order_id={3}&uid={4}&coins={5}&moneys={6}&time={7}&sign={8}", gkey, skey, platform, order_id, uid, coins, moneys, time, sign);

            string chargeUrl = "http://qpfish.lianzhong.com/gamechannel/api/channeluserapi/ybchange";

            WebRequest request = HttpWebRequest.Create(chargeUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strParams);
            request.ContentLength = buffer.Length;
            var stream = request.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
            
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var readData = reader.ReadToEnd();
            lb_msg.Text = "平台返回内容打印：" + readData;
        }

        public string GetMD5(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] md5data = md5.ComputeHash(buffer);

            string rlt= System.Text.Encoding.UTF8.GetString(md5data);
            string byte2string = "";
            for (int i=0; i < md5data.Length; i++)
            {
                //byte2string += md5data[i].ToString("x");//16位加密
                byte2string += md5data[i].ToString("x2");//32位加密
            }
            return byte2string;
            
        }
    }
}