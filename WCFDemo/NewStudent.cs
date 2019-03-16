using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFDemo
{
    public class NewStudent
    {
        public int id { get; set; }

        public String key { get; set; } // added this for my own ease in JS side 😉

        public String name { get; set; }

        public int age { get; set; }
    }
}