using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Common.ViewModels;
using NNShop.Data.Infrastructure;
using NNShop.Model.Models;

namespace NNShop.Data.Repositories
{
    //Để định nghĩa các phương thức mà k có sẵn trong Repository
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenusStatistic(string fromDate, string toDate);
        IEnumerable<OrderGetNameByProduct> GetByNameProduct(int id);
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<OrderGetNameByProduct> GetByNameProduct(int id)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ID",id)
            };
            return DbContext.Database.SqlQuery<OrderGetNameByProduct>("sp_GetNameProductById @ID", parameters);
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenusStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate)
            };
            return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        }
    }
}
