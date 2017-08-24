using FoodWeb.Service;
using FoodWeb.ViewModel;
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
            List<ProductViewModel> li = new List<ProductViewModel>();
            ProductViewModel pvm;
            foreach (var tmp in products)
            {
                pvm = new ProductViewModel();
                pvm.Id = tmp.ID;
                pvm.Name = tmp.Name;
                pvm.Price = 30000;
                pvm.Rating = 4;
                pvm.Discount = 20;
                pvm.Artical = "Món phở được coi là tinh hoa ẩm thực của người dân Thủ đô. " +
                    "Phở ở đây rất ngon và có nhiều vị như phở bò, phở gà cùng nhiều thương hiệu " +
                    "nổi tiếng như Phở Thìn, Phở Lý Quốc Sư, Phở Bát Đàn…. Không chỉ là món ăn quen thuộc" +
                    " của người dân mà phở còn là “đặc sản” mà bất cứ du khách nước ngoài nào đến " +
                    "Hà Nội đều muốn thưởng thức ít nhất 1 lần.";
                pvm.Description = "Món này là món gà rán cay phủ phô mai";

                List<string> comments = new List<string>();
                comments.Add("aaaaaaaaa");
                comments.Add("bbbbbbbbb");
                comments.Add("ccccccccc");
                comments.Add("ddddddddd");
                List<string> imgs = new List<string>();
                imgs.Add("https://unsplash.it/300/200");
                imgs.Add("https://unsplash.it/300/200");
                imgs.Add("https://unsplash.it/300/200");
                imgs.Add("https://unsplash.it/300/200");
                imgs.Add("https://unsplash.it/300/200");
                pvm.Comment = comments;
                pvm.imgs = imgs;
                li.Add(pvm);
            }
            return Ok(li);
        }
    }
}
