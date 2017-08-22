namespace FoodWeb.Model.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FWEntities : DbContext
    {
        public FWEntities()
            : base("name=FWEntities")
        {
        }

        public virtual DbSet<address> addresses { get; set; }
        public virtual DbSet<addresstype> addresstypes { get; set; }
        public virtual DbSet<bank> banks { get; set; }
        public virtual DbSet<bankaccount> bankaccounts { get; set; }
        public virtual DbSet<branch> branches { get; set; }
        public virtual DbSet<branch_email> branch_email { get; set; }
        public virtual DbSet<branch_phonenumber> branch_phonenumber { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<combo> comboes { get; set; }
        public virtual DbSet<combo_product> combo_product { get; set; }
        public virtual DbSet<confirmstatu> confirmstatus { get; set; }
        public virtual DbSet<cusrank> cusranks { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<customer_address> customer_address { get; set; }
        public virtual DbSet<customer_email> customer_email { get; set; }
        public virtual DbSet<customer_image> customer_image { get; set; }
        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<email> emails { get; set; }
        public virtual DbSet<facebook> facebooks { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<feedbackreply> feedbackreplies { get; set; }
        public virtual DbSet<image> images { get; set; }
        public virtual DbSet<imagedescription> imagedescriptions { get; set; }
        public virtual DbSet<import> imports { get; set; }
        public virtual DbSet<importpayment> importpayments { get; set; }
        public virtual DbSet<import_product> import_product { get; set; }
        public virtual DbSet<language> languages { get; set; }
        public virtual DbSet<moneycurrency> moneycurrencies { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<ordercancel> ordercancels { get; set; }
        public virtual DbSet<ordercofirm> ordercofirms { get; set; }
        public virtual DbSet<order_combo> order_combo { get; set; }
        public virtual DbSet<order_product> order_product { get; set; }
        public virtual DbSet<ordershipping> ordershippings { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<paymentstatu> paymentstatus { get; set; }
        public virtual DbSet<paymenttype> paymenttypes { get; set; }
        public virtual DbSet<phonenumber> phonenumbers { get; set; }
        public virtual DbSet<phonetype> phonetypes { get; set; }
        public virtual DbSet<producer> producers { get; set; }
        public virtual DbSet<producer_email> producer_email { get; set; }
        public virtual DbSet<producer_phonenumber> producer_phonenumber { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<productdescription> productdescriptions { get; set; }
        public virtual DbSet<productgroup> productgroups { get; set; }
        public virtual DbSet<productprice> productprices { get; set; }
        public virtual DbSet<productrating> productratings { get; set; }
        public virtual DbSet<productreview> productreviews { get; set; }
        public virtual DbSet<producttype> producttypes { get; set; }
        public virtual DbSet<promotion> promotions { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
        public virtual DbSet<search> searches { get; set; }
        public virtual DbSet<sex> sexes { get; set; }
        public virtual DbSet<shippingstatu> shippingstatus { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<tag> tags { get; set; }
        public virtual DbSet<voucher> vouchers { get; set; }
        public virtual DbSet<voucher_customer> voucher_customer { get; set; }
        public virtual DbSet<website> websites { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<address>()
                .HasMany(e => e.branches)
                .WithRequired(e => e.address)
                .HasForeignKey(e => e.Address_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<address>()
                .HasMany(e => e.customer_address)
                .WithRequired(e => e.address)
                .HasForeignKey(e => e.Address_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<address>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.address)
                .HasForeignKey(e => e.Address_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<address>()
                .HasMany(e => e.producers)
                .WithRequired(e => e.address)
                .HasForeignKey(e => e.Address_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<addresstype>()
                .HasMany(e => e.customer_address)
                .WithRequired(e => e.addresstype)
                .HasForeignKey(e => e.AddressType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bank>()
                .HasMany(e => e.bankaccounts)
                .WithRequired(e => e.bank)
                .HasForeignKey(e => e.Bank_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<branch>()
                .HasMany(e => e.branch_email)
                .WithRequired(e => e.branch)
                .HasForeignKey(e => e.Branch_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<branch>()
                .HasMany(e => e.branch_phonenumber)
                .WithRequired(e => e.branch)
                .HasForeignKey(e => e.Branch_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<branch>()
                .HasMany(e => e.imports)
                .WithOptional(e => e.branch)
                .HasForeignKey(e => e.Branch_ID);

            modelBuilder.Entity<city>()
                .HasMany(e => e.districts)
                .WithRequired(e => e.city)
                .HasForeignKey(e => e.City_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<combo>()
                .HasMany(e => e.combo_product)
                .WithRequired(e => e.combo)
                .HasForeignKey(e => e.Combo_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<combo>()
                .HasMany(e => e.order_combo)
                .WithRequired(e => e.combo)
                .HasForeignKey(e => e.Combo_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<confirmstatu>()
                .HasMany(e => e.ordercofirms)
                .WithRequired(e => e.confirmstatu)
                .HasForeignKey(e => e.ConfirmStatus_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cusrank>()
                .HasMany(e => e.customers)
                .WithRequired(e => e.cusrank)
                .HasForeignKey(e => e.CusRank_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cusrank>()
                .HasMany(e => e.promotions)
                .WithMany(e => e.cusranks)
                .Map(m => m.ToTable("promotion-cusrank", "mydb").MapLeftKey("CusRank_ID").MapRightKey("Promotion_ID"));

            modelBuilder.Entity<customer>()
                .Property(e => e.CreatedTime)
                .HasPrecision(0);

            modelBuilder.Entity<customer>()
                .Property(e => e.InfoUpdatedTime)
                .HasPrecision(0);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.customer_address)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.customer_email)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.customer_image)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.feedbacks)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.productratings)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.searches)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.voucher_customer)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.Customer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.phonenumbers)
                .WithMany(e => e.customers)
                .Map(m => m.ToTable("customer-phonenumber", "mydb").MapLeftKey("Customer_ID").MapRightKey("PhoneNumber_ID"));

            modelBuilder.Entity<customer>()
                .HasMany(e => e.products)
                .WithMany(e => e.customers)
                .Map(m => m.ToTable("favoriteproduct", "mydb").MapLeftKey("Customer_ID").MapRightKey("Product_ID"));

            modelBuilder.Entity<district>()
                .HasMany(e => e.addresses)
                .WithRequired(e => e.district)
                .HasForeignKey(e => e.District_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<email>()
                .HasMany(e => e.branch_email)
                .WithRequired(e => e.email)
                .HasForeignKey(e => e.Email_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<email>()
                .HasMany(e => e.customer_email)
                .WithRequired(e => e.email)
                .HasForeignKey(e => e.Email_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<email>()
                .HasMany(e => e.producer_email)
                .WithRequired(e => e.email)
                .HasForeignKey(e => e.Email_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<facebook>()
                .HasMany(e => e.customers)
                .WithOptional(e => e.facebook)
                .HasForeignKey(e => e.Facebook_ID);

            modelBuilder.Entity<feedback>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<feedback>()
                .HasMany(e => e.feedbackreplies)
                .WithRequired(e => e.feedback)
                .HasForeignKey(e => e.Feedback_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<feedbackreply>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<image>()
                .HasMany(e => e.customer_image)
                .WithRequired(e => e.image)
                .HasForeignKey(e => e.Image_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<image>()
                .HasOptional(e => e.imagedescription)
                .WithRequired(e => e.image);

            modelBuilder.Entity<image>()
                .HasMany(e => e.products)
                .WithMany(e => e.images)
                .Map(m => m.ToTable("product-image", "mydb").MapLeftKey("Image_ID").MapRightKey("Product_ID"));

            modelBuilder.Entity<import>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<import>()
                .HasMany(e => e.importpayments)
                .WithRequired(e => e.import)
                .HasForeignKey(e => e.Import_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<import>()
                .HasMany(e => e.import_product)
                .WithRequired(e => e.import)
                .HasForeignKey(e => e.Import_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<importpayment>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<language>()
                .HasMany(e => e.customers)
                .WithOptional(e => e.language)
                .HasForeignKey(e => e.Language_ID);

            modelBuilder.Entity<language>()
                .HasMany(e => e.imagedescriptions)
                .WithRequired(e => e.language)
                .HasForeignKey(e => e.Language_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<language>()
                .HasMany(e => e.productdescriptions)
                .WithRequired(e => e.language)
                .HasForeignKey(e => e.Language_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<moneycurrency>()
                .HasMany(e => e.customers)
                .WithOptional(e => e.moneycurrency)
                .HasForeignKey(e => e.MoneyCurrency_ID);

            modelBuilder.Entity<moneycurrency>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.moneycurrency)
                .HasForeignKey(e => e.MoneyCurrency_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<order>()
                .HasOptional(e => e.ordercancel)
                .WithRequired(e => e.order);

            modelBuilder.Entity<order>()
                .HasOptional(e => e.ordercofirm)
                .WithRequired(e => e.order);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_combo)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.Order_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_product)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.Order_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasOptional(e => e.ordershipping)
                .WithRequired(e => e.order);

            modelBuilder.Entity<order>()
                .HasOptional(e => e.payment)
                .WithRequired(e => e.order);

            modelBuilder.Entity<order>()
                .HasMany(e => e.vouchers)
                .WithMany(e => e.orders)
                .Map(m => m.ToTable("order-voucher", "mydb").MapLeftKey("Order_ID").MapRightKey("Voucher_ID"));

            modelBuilder.Entity<order>()
                .HasMany(e => e.promotions)
                .WithMany(e => e.orders)
                .Map(m => m.ToTable("promotion-order", "mydb").MapLeftKey("Order_ID").MapRightKey("Promotion_ID"));

            modelBuilder.Entity<ordercancel>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<ordercofirm>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<ordershipping>()
                .Property(e => e.StartTime)
                .HasPrecision(0);

            modelBuilder.Entity<ordershipping>()
                .Property(e => e.EndTime)
                .HasPrecision(0);

            modelBuilder.Entity<payment>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<paymentstatu>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.paymentstatu)
                .HasForeignKey(e => e.PaymentStatus_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<paymenttype>()
                .HasMany(e => e.importpayments)
                .WithRequired(e => e.paymenttype)
                .HasForeignKey(e => e.PaymentType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<paymenttype>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.paymenttype)
                .HasForeignKey(e => e.PaymentType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phonenumber>()
                .HasMany(e => e.branch_phonenumber)
                .WithRequired(e => e.phonenumber)
                .HasForeignKey(e => e.PhoneNumber_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phonenumber>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.phonenumber)
                .HasForeignKey(e => e.PhoneNumber_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phonenumber>()
                .HasMany(e => e.producer_phonenumber)
                .WithRequired(e => e.phonenumber)
                .HasForeignKey(e => e.PhoneNumber_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phonetype>()
                .HasMany(e => e.phonenumbers)
                .WithRequired(e => e.phonetype)
                .HasForeignKey(e => e.PhoneType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producer>()
                .HasMany(e => e.branches)
                .WithRequired(e => e.producer)
                .HasForeignKey(e => e.Producer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producer>()
                .HasMany(e => e.imports)
                .WithRequired(e => e.producer)
                .HasForeignKey(e => e.Producer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producer>()
                .HasMany(e => e.producer_email)
                .WithRequired(e => e.producer)
                .HasForeignKey(e => e.Producer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producer>()
                .HasMany(e => e.producer_phonenumber)
                .WithRequired(e => e.producer)
                .HasForeignKey(e => e.Producer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producer>()
                .HasMany(e => e.products)
                .WithMany(e => e.producers)
                .Map(m => m.ToTable("product-producer", "mydb").MapLeftKey("Producer_ID").MapRightKey("Product_ID"));

            modelBuilder.Entity<product>()
                .HasMany(e => e.combo_product)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Product_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.import_product)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Product_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.order_product)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Product_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasOptional(e => e.productprice)
                .WithRequired(e => e.product);

            modelBuilder.Entity<product>()
                .HasMany(e => e.productratings)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Product_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.tags)
                .WithMany(e => e.products)
                .Map(m => m.ToTable("product-tag", "mydb").MapLeftKey("Product_ID").MapRightKey("Tag_ID"));

            modelBuilder.Entity<product>()
                .HasMany(e => e.promotions)
                .WithMany(e => e.products)
                .Map(m => m.ToTable("promotion-product", "mydb").MapLeftKey("Product_ID").MapRightKey("Promotion_ID"));

            modelBuilder.Entity<product>()
                .HasMany(e => e.promotions1)
                .WithMany(e => e.products1)
                .Map(m => m.ToTable("promotion-productgroup", "mydb").MapLeftKey("Product_ID").MapRightKey("Promotion_ID"));

            modelBuilder.Entity<product>()
                .HasMany(e => e.promotions2)
                .WithMany(e => e.products2)
                .Map(m => m.ToTable("promotion-producttype", "mydb").MapLeftKey("Product_ID").MapRightKey("Promotion_ID"));

            modelBuilder.Entity<product>()
                .HasMany(e => e.vouchers)
                .WithMany(e => e.products)
                .Map(m => m.ToTable("voucher-product", "mydb").MapLeftKey("Product_ID").MapRightKey("Voucher_ID"));

            modelBuilder.Entity<productgroup>()
                .HasMany(e => e.producttypes)
                .WithRequired(e => e.productgroup)
                .HasForeignKey(e => e.ProductGroup_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<productgroup>()
                .HasMany(e => e.vouchers)
                .WithMany(e => e.productgroups)
                .Map(m => m.ToTable("voucher-productgroup", "mydb").MapLeftKey("ProductGroup_ID").MapRightKey("Voucher_ID"));

            modelBuilder.Entity<productrating>()
                .Property(e => e.time)
                .HasPrecision(0);

            modelBuilder.Entity<productrating>()
                .HasOptional(e => e.productreview)
                .WithRequired(e => e.productrating);

            modelBuilder.Entity<productreview>()
                .Property(e => e.time)
                .HasPrecision(0);

            modelBuilder.Entity<producttype>()
                .HasMany(e => e.products)
                .WithRequired(e => e.producttype)
                .HasForeignKey(e => e.ProductType_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<producttype>()
                .HasMany(e => e.vouchers)
                .WithMany(e => e.producttypes)
                .Map(m => m.ToTable("voucher-producttype", "mydb").MapLeftKey("ProductType_ID").MapRightKey("Voucher_ID"));

            modelBuilder.Entity<promotion>()
                .Property(e => e.StartTime)
                .HasPrecision(0);

            modelBuilder.Entity<promotion>()
                .Property(e => e.EndTime)
                .HasPrecision(0);

            modelBuilder.Entity<rating>()
                .HasMany(e => e.productratings)
                .WithRequired(e => e.rating)
                .HasForeignKey(e => e.Rating_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<search>()
                .Property(e => e.Time)
                .HasPrecision(0);

            modelBuilder.Entity<search>()
                .HasMany(e => e.tags)
                .WithMany(e => e.searches)
                .Map(m => m.ToTable("search-tag", "mydb").MapLeftKey(new[] { "Search_ID", "Search_Customer_ID" }).MapRightKey("Tag_ID"));

            modelBuilder.Entity<sex>()
                .HasMany(e => e.customers)
                .WithOptional(e => e.sex)
                .HasForeignKey(e => e.Sex_ID);

            modelBuilder.Entity<shippingstatu>()
                .HasMany(e => e.ordershippings)
                .WithRequired(e => e.shippingstatu)
                .HasForeignKey(e => e.ShippingStatus_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.feedbackreplies)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.Staff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.imports)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.Staff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.importpayments)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.Staff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.ordercofirms)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.Staff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.ordershippings)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.Staff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.staff)
                .HasForeignKey(e => e.Staff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<voucher>()
                .HasMany(e => e.voucher_customer)
                .WithRequired(e => e.voucher)
                .HasForeignKey(e => e.Voucher_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<voucher_customer>()
                .Property(e => e.ExpiryDate)
                .HasPrecision(0);
        }
    }
}
