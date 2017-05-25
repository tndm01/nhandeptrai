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
    public interface IContactRepository : IRepository<ContactDetail>
    {
    }

    public class ContactRepository : RepositoryBase<ContactDetail>, IContactRepository
    {
        public ContactRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
