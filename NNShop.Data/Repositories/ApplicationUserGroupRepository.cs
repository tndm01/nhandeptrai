using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Data.Infrastructure;
using NNShop.Model.Models;

namespace NNShop.Data.Repositories
{
    public interface IApplicationUserGroupRepository : IRepository<ApplicationUserGroup>
    {

    }

    public class ApplicationUserGroupRepository : RepositoryBase<ApplicationUserGroup>, IApplicationUserGroupRepository
    {
        public ApplicationUserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
