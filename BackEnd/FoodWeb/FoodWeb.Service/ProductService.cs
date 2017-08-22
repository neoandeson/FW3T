using System;
using System.Collections.Generic;
using FoodWeb.Model.Models;
using FoodWeb.Data.Infrastructure;
using FoodWeb.Data.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWeb.Service
{
    public interface IProductService
    {
        IEnumerable<product> GetProducts(string name = null);
        product GetProduct(int id);
        product GetProduct(string name);
        void CreateProduct(product Product);
        void EditProduct(product Product);
        void RemoveProduct(int id);
        void SaveProduct();
        void UnRemoveProduct(int id);//BE_Tien: Set Product isDelete = false
        void AddSubProduct(int ownId, int subId);//BE_Tien: Add subProduct to OwnProduct's list
        void RemoveSubProduct(int ownId, int subId);
    }

    public class ProductService : IProductService
    {
        public void AddSubProduct(int ownId, int subId)
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(product Product)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(product Product)
        {
            throw new NotImplementedException();
        }

        public product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public product GetProduct(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<product> GetProducts(string name = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubProduct(int ownId, int subId)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct()
        {
            throw new NotImplementedException();
        }

        public void UnRemoveProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
