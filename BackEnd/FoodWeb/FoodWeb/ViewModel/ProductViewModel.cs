using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodWeb.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Membername is required")]
        //[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])$", ErrorMessage = "Invalid Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public float Discount { get; set; }
        public IEnumerable<string> imgs { get; set; }
        public string Artical { get; set; }
        public IEnumerable<string> Comment { get; set; }
    }
}