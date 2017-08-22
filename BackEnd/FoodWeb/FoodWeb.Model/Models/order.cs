namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            order_combo = new HashSet<order_combo>();
            order_product = new HashSet<order_product>();
            vouchers = new HashSet<voucher>();
            promotions = new HashSet<promotion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Customer_ID { get; set; }

        public int Address_ID { get; set; }

        public int PhoneNumber_ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public float? Discount { get; set; }

        public virtual address address { get; set; }

        public virtual customer customer { get; set; }

        public virtual phonenumber phonenumber { get; set; }

        public virtual ordercancel ordercancel { get; set; }

        public virtual ordercofirm ordercofirm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_combo> order_combo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_product> order_product { get; set; }

        public virtual ordershipping ordershipping { get; set; }

        public virtual payment payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voucher> vouchers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<promotion> promotions { get; set; }
    }
}
