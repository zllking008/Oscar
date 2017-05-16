using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Record : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            int record = 0;
            Random rd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var tmp = rd.Next(1, 100);
                if (tmp >= 60)
                {
                    record++;
                }
                System.Threading.Thread.Sleep(1);
            }
            Response.Write(string.Format("{0}-{1}%", currentTime.ToString("mm:ss"), record));
        }
    }
}