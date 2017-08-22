namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.productrating")]
    public partial class productrating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Customer_ID { get; set; }

        public int Product_ID { get; set; }

        public int Rating_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? time { get; set; }

        public virtual customer customer { get; set; }

        public virtual product product { get; set; }

        public virtual rating rating { get; set; }

        public virtual productreview productreview { get; set; }
    }
}
