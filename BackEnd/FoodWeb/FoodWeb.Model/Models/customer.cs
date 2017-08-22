namespace FoodWeb.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            customer_address = new HashSet<customer_address>();
            customer_email = new HashSet<customer_email>();
            customer_image = new HashSet<customer_image>();
            feedbacks = new HashSet<feedback>();
            orders = new HashSet<order>();
            productratings = new HashSet<productrating>();
            searches = new HashSet<search>();
            voucher_customer = new HashSet<voucher_customer>();
            phonenumbers = new HashSet<phonenumber>();
            products = new HashSet<product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(45)]
        public string Username { get; set; }

        [Required]
        [StringLength(45)]
        public string Password { get; set; }

        [StringLength(45)]
        public string FirstName { get; set; }

        [StringLength(45)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? InfoUpdatedTime { get; set; }

        public int? Sex_ID { get; set; }

        public int? MoneyCurrency_ID { get; set; }

        public int? Language_ID { get; set; }

        public int? Facebook_ID { get; set; }

        public int CusRank_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RankUpdatedTime { get; set; }

        public virtual cusrank cusrank { get; set; }

        public virtual facebook facebook { get; set; }

        public virtual language language { get; set; }

        public virtual moneycurrency moneycurrency { get; set; }

        public virtual sex sex { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_address> customer_address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_email> customer_email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer_image> customer_image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productrating> productratings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<search> searches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voucher_customer> voucher_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phonenumber> phonenumbers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
