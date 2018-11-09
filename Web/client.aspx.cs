using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace Web
{
    public partial class client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime current1 = DateTime.Now;
            //System.Threading.Thread.Sleep(200);
            //DateTime current2 = DateTime.Now;
            //Response.Write(current2.Millisecond);

            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //Workbooks wbs = app.Workbooks;
            //Microsoft.Office.Interop.Excel.Worksheet ws;

            //统计1000秒内的随机数的生成情况（0-99之间的随机数，0-9统计到第一组，以此类推……），结果表明：随机数均匀分布
            //int[] arrayint = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //Random rd = new Random();
            //for(int i = 0; i < 1000; i++) { 
            //    int tmp = rd.Next(0, 100);
            //    arrayint[tmp / 10]++;
            //    System.Threading.Thread.Sleep(1000);
            //}
            //for(int j = 0; j < arrayint.Length; j++)
            //{
            //    Response.Write(string.Format("{0}-{1}: {2}<br />", j *10+1, (j + 1) * 10, arrayint[j]));
            //}


            //统计大于60的时段（5秒为一个段，1分钟分为12个段），1200秒内
            int[] arrayint2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Random rd2 = new Random();
            int record = 0;
            for (int i = 0; i < 1200; i++)
            {
                int tmp = rd2.Next(0, 100);
                DateTime current = DateTime.Now;
                if (tmp >= 60)
                {
                    record++;
                    var seconds = current.Second;
                    arrayint2[seconds / 5]++;
                }
                System.Threading.Thread.Sleep(1000);
            }
            Response.Write("总数：" + record + "<br />");
            for (int j = 0; j < arrayint2.Length; j++)
            {
                Response.Write(string.Format("{0}-{1}: {2}<br />", j *5+1, (j + 1) * 5, arrayint2[j]));
            }
            
        }
    }
}