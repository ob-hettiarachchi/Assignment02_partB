using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//OB Hettiarachchi - 20908883 || KAD Miththaka - 20907819  || Assignment 02 - part B

namespace Server
{
    internal class Clients
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public Nullable<int> port { get; set; }
    }
}
