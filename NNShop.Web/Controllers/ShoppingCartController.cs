using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using Microsoft.AspNet.Identity;
using NNShop.Common;
using NNShop.Model.Models;
using NNShop.Service;
using NNShop.Web.App_Start;
using NNShop.Web.Infrastructure.Extensions;
using NNShop.Web.Models;

namespace NNShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        IProductService _productService;
        IOrderService _orderService;
        private ApplicationUserManager _userManager;

        public ShoppingCartController(IOrderService orderService,IProductService productService, ApplicationUserManager userManager)
        {
            this._productService = productService;
            this._orderService = orderService;
            this._userManager = userManager;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            if(Session[CommonContants.SessionCart] == null)
                Session[CommonContants.SessionCart] = new List<ShoppingCartViewModel>();
            return View();
        }

        public ActionResult CheckOut()
        {
            if (Session[CommonContants.SessionCart] == null)
            {
                return Redirect("/gio-hang.html");
            }
            return View();
        }

        public JsonResult CreateOrder(string orderViewModel)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderNew = new Order();
            orderNew.UpdateOrder(order);

            if (Request.IsAuthenticated)
            {
                orderNew.CustomerId = User.Identity.GetUserId();
                orderNew.CreatedBy = User.Identity.GetUserName();
            }

            var cart = (List<ShoppingCartViewModel>)Session[CommonContants.SessionCart];
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            bool isEnough = true;

            foreach(var item in cart)
            {
                var detail = new OrderDetail();
                detail.ProductID = item.ProductId;
                detail.Quantity = item.Quantity;
                detail.Price = item.Product.Price;
                orderDetails.Add(detail);
                isEnough = _productService.sellProduct(item.ProductId, item.Quantity);
                break;
            }

            if (isEnough)
            {
                _orderService.Create(orderNew, orderDetails);
                _productService.Save();
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "Không đủ hàng!"
                });
            }
        }

        public JsonResult GetUser()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new {
                    data = user,
                    status = true
                });
            }
            return Json(new {
                status = false
            });
        }

        public JsonResult GetAll()
        {
            if (Session[CommonContants.SessionCart] == null)
                Session[CommonContants.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)Session[CommonContants.SessionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonContants.SessionCart];
            var product = _productService.GetById(productId);
            if(cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }
            if(product.Quantity == 0)
            {
                return Json(new
                {
                    status = false,
                    message = "Sản phẩm này hiện đang hết hàng!"
                });
            }
            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            Session[CommonContants.SessionCart] = cart;
            return Json(new
            {
                status = true,
            });
        }

        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonContants.SessionCart];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                Session[CommonContants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonContants.SessionCart];
            foreach (var item in cartSession)
            {
                foreach (var jitem in cartViewModel)
                {
                    if (item.ProductId == jitem.ProductId)
                    {
                        item.Quantity = jitem.Quantity;
                    }
                }
            }
            Session[CommonContants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonContants.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}