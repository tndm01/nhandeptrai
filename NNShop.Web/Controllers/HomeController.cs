using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NNShop.Model.Models;
using NNShop.Service;
using NNShop.Web.Models;

namespace NNShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;

        public HomeController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Không thể gọi trực tiếp.
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        //Không thể gọi trực tiếp.
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        //Không thể gọi trực tiếp.
        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

            return PartialView(listProductCategoryViewModel);
        }
    }
}