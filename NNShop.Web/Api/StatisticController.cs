﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NNShop.Service;
using NNShop.Web.Infrastructure.Core;

namespace NNShop.Web.Api
{
    //[Authorize]
    [RoutePrefix("api/statistic")]
    public class StatisticController : ApiControllerBase
    {
        IStatisticService _statisticService;
        public StatisticController(IErrorService errorService, IStatisticService statisticService) : base(errorService)
        {
            this._statisticService = statisticService;
        }

        [Route("getrevanue")]
        [HttpGet]
        public HttpResponseMessage GetRevenuesStatistic(HttpRequestMessage request, string fromDate, string toDate)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
                HttpResponseMessage respone = request.CreateResponse(HttpStatusCode.OK, model);
                return respone;
            });
        }
    }
}
