using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NNShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tên .")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập Email .")]
        public string Email { set; get; }

        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }

        public bool Status { set; get; }

        public ContactViewModel ContactDetail { set; get; }
    }
}