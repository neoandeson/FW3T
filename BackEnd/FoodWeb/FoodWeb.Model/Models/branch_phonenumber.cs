namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.branch-phonenumber")]
    public partial class branch_phonenumber
    {
        [StringLength(45)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Branch_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PhoneNumber_ID { get; set; }

        public virtual branch branch { get; set; }

        public virtual phonenumber phonenumber { get; set; }
    }
}
