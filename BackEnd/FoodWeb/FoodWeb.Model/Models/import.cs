namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.import")]
    public partial class import
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public import()
        {
            importpayments = new HashSet<importpayment>();
            import_product = new HashSet<import_product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Time { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        public int Producer_ID { get; set; }

        public int? Branch_ID { get; set; }

        public int Staff_ID { get; set; }

        public virtual branch branch { get; set; }

        public virtual producer producer { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<importpayment> importpayments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<import_product> import_product { get; set; }
    }
}
