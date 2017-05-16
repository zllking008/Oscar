using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();

            //client.Headers.Add("content-type", "application/xml");
            var user1 = client.DownloadString("http://localhost:3274/Member.svc/User/1");
            Console.WriteLine(user1);

            client.Headers.Add("content-type", "application/x-www-form-urlencoded");


            var usern = client.UploadString("http://localhost:3274/Member.svc/User/admin/admin", "POST",String.Empty);
            Console.WriteLine(usern);


            Console.ReadLine();
        }
    }
}
