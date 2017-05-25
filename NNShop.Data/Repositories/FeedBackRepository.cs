using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Data.Infrastructure;
using NNShop.Model.Models;

namespace NNShop.Data.Repositories
{
    //Để định nghĩa các phương thức mà k có sẵn trong Repository
    public interface IFeedBackRepository : IRepository<Feedback>
    {
    }

    public class FeedBackRepository : RepositoryBase<Feedback>, IFeedBackRepository
    {
        public FeedBackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
