using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ProductViewModel> HotOffers { set; get; }
        public IEnumerable<ProductViewModel> TopHotProducts { set; get; }
        public IEnumerable<ProductViewModel> GetListAllProduct { set; get;}
    }
}