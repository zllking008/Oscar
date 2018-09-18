using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class random : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Bitmap bitmap = GetBitmap();

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.ClearContent();
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        private Bitmap GetBitmap()
        {
            int width = 2000;
            int height = 100;
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.SeaShell);
                g.SmoothingMode = SmoothingMode.HighQuality;
                Random random = new Random();
                for (int i = 0; i < bmp.Width/10; i++)
                {
                    int x = i*10;
                    int record = 0;
                    Random rd = new Random();

                    for (int k = 0; k < 1000; k++)
                    {
                        var tmp = rd.Next(1, 100);
                        if (tmp >= 50)
                        {
                            record++;
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                    int y = record / 10;
                    //int y = random.Next(bmp.Height);
                    for(int j= y;j<bmp.Height;j++)
                    {
                        bmp.SetPixel(x, j, Color.FromArgb(0, 0, 0));
                    }
                    //bmp.SetPixel(x, y, Color.FromArgb(0,0,0));
                    //System.Threading.Thread.Sleep(1);
                }
                //for (int i = 0; i < 500; i++)
                //{
                //    var hashCode =Math.Abs( Guid.NewGuid().GetHashCode() % bmp.Height);
                //    int x = i;
                //    int y = hashCode;
                //    bmp.SetPixel(x, y, Color.FromArgb(0, 255, 0));
                //}
            }
            return bmp;
        }

        public void Pool()
        {
            System.Threading.ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {

                }
            });

            //ThreadPool.QueueUserWorkItem(new WaitCallback(addtest), "Testaa");
            //private void addtest(object aa)
            //{
            //    long result = 0;
            //    for (int i = 0; i < 1000000000; i++)
            //    {
            //        result += i;
            //    }
            //    MessageBox.Show(result.ToString() + aa.ToString());

            //}
    }

    }
}