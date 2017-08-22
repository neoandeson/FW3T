namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.productreview")]
    public partial class productreview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductRating_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? time { get; set; }

        public virtual productrating productrating { get; set; }
    }
}
