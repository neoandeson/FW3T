namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.payment")]
    public partial class payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_ID { get; set; }

        public int MoneyCurrency_ID { get; set; }

        public int PaymentType_ID { get; set; }

        public int PaymentStatus_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Time { get; set; }

        public int Staff_ID { get; set; }

        public virtual moneycurrency moneycurrency { get; set; }

        public virtual order order { get; set; }

        public virtual paymentstatu paymentstatu { get; set; }

        public virtual paymenttype paymenttype { get; set; }

        public virtual staff staff { get; set; }
    }
}
