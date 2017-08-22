using FoodWeb.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWeb.Model;
using FoodWeb.Model.Models;

namespace FoodWeb.Data.Repositories
{
    public class ProductRepository : RepositoryBase<product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public product GetProductByName(string ProductName)
        {
            product Product = this.DbContext.products.Where(p => p.Name == ProductName).FirstOrDefault();
            return Product;
        }
    }

    public interface IProductRepository : IRepository<product>
    {
        product GetProductByName(string ProductName);
    }
}
