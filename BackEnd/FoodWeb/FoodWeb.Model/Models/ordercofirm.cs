namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.ordercofirm")]
    public partial class ordercofirm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_ID { get; set; }

        public int ConfirmStatus_ID { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        public int Staff_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Time { get; set; }

        public virtual confirmstatu confirmstatu { get; set; }

        public virtual order order { get; set; }

        public virtual staff staff { get; set; }
    }
}