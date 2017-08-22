namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.customer-image")]
    public partial class customer_image
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Image_ID { get; set; }

        public short? IsCurrentAvatar { get; set; }

        public virtual customer customer { get; set; }

        public virtual image image { get; set; }
    }
}
