namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.productdescription")]
    public partial class productdescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Language_ID { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        public virtual language language { get; set; }
    }
}
