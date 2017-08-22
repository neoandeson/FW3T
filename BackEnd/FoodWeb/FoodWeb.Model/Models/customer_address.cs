namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.customer-address")]
    public partial class customer_address
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Address_ID { get; set; }

        public int AddressType_ID { get; set; }

        public virtual address address { get; set; }

        public virtual addresstype addresstype { get; set; }

        public virtual customer customer { get; set; }
    }
}
