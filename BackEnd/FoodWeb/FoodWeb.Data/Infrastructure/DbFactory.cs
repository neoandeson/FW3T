using FoodWeb.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWeb.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        FWEntities dbContext;

        public FWEntities Init()
        {
            return dbContext ?? (dbContext = new FWEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }

    public interface IDbFactory : IDisposable
    {
        FWEntities Init();
    }
}
