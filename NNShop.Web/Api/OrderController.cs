using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using AutoMapper;
using NNShop.Model.Models;
using NNShop.Service;
using NNShop.Web.Infrastructure.Core;
using NNShop.Web.Infrastructure.Extensions;
using NNShop.Web.Models;

namespace NNShop.Web.Api
{
    [RoutePrefix("api/order")]
    [Authorize]
    public class OrderController : ApiControllerBase
    {
        private IOrderService _orderSerivce;

        public OrderController(IErrorService errorService, IOrderService orderService)
            : base(errorService)
        {
            this._orderSerivce = orderService;
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _orderSerivce.Delete(id);
                    _orderSerivce.SaveChanges();

                    var responseData = Mapper.Map<Order, OrderViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedOrder)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listOrder = new JavaScriptSerializer().Deserialize<List<int>>(checkedOrder);
                    foreach (var item in listOrder)
                    {
                        _orderSerivce.Delete(item);
                    }

                    _orderSerivce.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listOrder.Count);
                }

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _orderSerivce.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(query);

                var paginationSet = new PaginationSet<OrderViewModel>()
                {
                    Items = responseData,
                    Pages = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, OrderViewModel orderViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var orderDb = _orderSerivce.GetById(orderViewModel.ID);
                    orderDb.UpdateOrder(orderViewModel);
                    _orderSerivce.Update(orderDb);
                    _orderSerivce.SaveChanges();
                    var responseData = Mapper.Map<Order,OrderViewModel>(orderDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _orderSerivce.GetById(id);
                    var responseData = Mapper.Map<Order,OrderViewModel>(model);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("getbyname/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByNameProduct(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _orderSerivce.GetNameProduct(id);
                HttpResponseMessage respone = request.CreateResponse(HttpStatusCode.OK, model);
                return respone;
            });
        }

    }
}
