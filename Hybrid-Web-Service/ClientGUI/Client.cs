using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace ClientGUI
{
    public class Clients
    {
        public Clients()
        {
            Id = 0;
            name = "";
            ip = "";
            port = 0;
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public Nullable<int> port { get; set; }

        private static Clients instance = null;
        public static Clients Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Clients();
                }
                return instance;
            }
        }
    }

}
