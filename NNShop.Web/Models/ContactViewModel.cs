using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNShop.Web.Models
{
    public class ContactViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public string Website { set; get; }

        public string Address { set; get; }

        public string Orther { set; get; }

        public double Lat { set; get; }

        public double Lng { set; get; }

        public bool Status { set; get; }
    }
}