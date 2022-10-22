using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //server start
            Console.WriteLine("Welcome to server");

            var tcp = new NetTcpBinding();
            var host = new ServiceHost(typeof(DataServer));

            host.AddServiceEndpoint(typeof(DataServerInterface), tcp, "net.tcp://localhost:8100/DataService");


            host.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            host.Close();

        }
    }
}
