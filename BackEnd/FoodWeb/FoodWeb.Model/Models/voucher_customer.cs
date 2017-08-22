namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.voucher-customer")]
    public partial class voucher_customer
    {
        [Column(TypeName = "datetime2")]
        public DateTime? ExpiryDate { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Voucher_ID { get; set; }

        public virtual customer customer { get; set; }

        public virtual voucher voucher { get; set; }
    }
}
