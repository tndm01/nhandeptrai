using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Data.Infrastructure;
using NNShop.Model.Models;

namespace NNShop.Data.Repositories
{
    public interface IApplicationRoleGroupRepository : IRepository<ApplicationRoleGroup>
    {

    }
    public class ApplicationRoleGroupRepository : RepositoryBase<ApplicationRoleGroup>, IApplicationRoleGroupRepository
    {
        public ApplicationRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
