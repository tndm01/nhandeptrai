using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Common.ViewModels;
using NNShop.Data.Repositories;

namespace NNShop.Service
{
    public interface IStatisticService
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class StatisticService : IStatisticService
    {
        IOrderRepository _orderRepository;
        public StatisticService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            return _orderRepository.GetRevenusStatistic(fromDate, toDate);
        }
    }
}
