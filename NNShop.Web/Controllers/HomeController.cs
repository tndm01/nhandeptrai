using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NNShop.Common;
using NNShop.Model.Models;
using NNShop.Service;
using NNShop.Web.Models;

namespace NNShop.Web.Controllers
{
    public class HomeController : Controller
    {
        ICommonService _commonService;
        IProductCategoryService _productCategoryService;
        IProductService _productService;

        public HomeController(IProductCategoryService productCategory, ICommonService commonService, IProductService productService)
        {
            _commonService = commonService;
            _productCategoryService = productCategory;
            _productService = productService;
        }

        // GET: Home
        //[OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            var lastestProductModel = _productService.GetLastest(4);
            var topsaleProductModel = _productService.GetHotProduct(4);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topsaleProductModel);
            homeViewModel.HotOffers = lastestProductViewModel;
            homeViewModel.TopHotProducts = topSaleProductViewModel;
            return View(homeViewModel);
        }

        //Header
        //[ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        public ActionResult Header()
        {
            var cart = Session[CommonContants.SessionCart];
            var list = new List<ShoppingCartViewModel>();
            if(cart != null)
            {
                list = (List<ShoppingCartViewModel>)cart;
            }
            return PartialView(list);
        }

        //Footer
        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.Time = DateTime.Now.ToString("T");
            return PartialView();
        }

        //Category
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listCategoryViewModel);
        }

    }
}