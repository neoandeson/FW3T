using FoodWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodWeb.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        //Constructor
        public ProductController(IProductService _productService)
        {
            this._productService = _productService;
        }

        //Get All Products
        public IHttpActionResult GetProducts()
        {
            var products = _productService.GetProducts().ToList();
            return Ok(products);
        }
    }
}
