using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NnShopDbContext dbContext;

        public NnShopDbContext Init()
        {
            //Kiểm tra nếu null sẽ khởi tạo new mới.
            return dbContext ?? (dbContext = new NnShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
