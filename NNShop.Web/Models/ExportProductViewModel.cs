﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NNShop.Web.Models
{
    [Serializable]
    public class ExportProductViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public int CategoryID { set; get; }

        public string Image { set; get; }

        public decimal Price { set; get; }
        public decimal? Promotion { set; get; }
        public int? Warranty { set; get; }
        public string Description { set; get; }

        public bool? HomeFlag { set; get; }
        public bool? HotFlag { set; get; }

        [Required]
        public bool Status { set; get; }

        public int Quantity { set; get; }

        public decimal OriginalPrice { set; get; }
    }
}