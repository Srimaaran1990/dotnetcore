using Microsoft.EntityFrameworkCore;
using DotnetCore.Business.Entities;

namespace Chinook.Data
{
    public class HomeFoodEntities : DbContext
    {

        public HomeFoodEntities()
        {
            
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MAS_AddressType> MAS_AddressType { get; set; }
        public virtual DbSet<MAS_Area> MAS_Area { get; set; }
        public virtual DbSet<MAS_Category> MAS_Category { get; set; }
        public virtual DbSet<MAS_ChefType> MAS_ChefType { get; set; }
        public virtual DbSet<MAS_City> MAS_City { get; set; }
        public virtual DbSet<MAS_DeliveryLocation> MAS_DeliveryLocation { get; set; }
        public virtual DbSet<MAS_Discount> MAS_Discount { get; set; }
        public virtual DbSet<MAS_DiscountType> MAS_DiscountType { get; set; }
        public virtual DbSet<MAS_Food> MAS_Food { get; set; }
        public virtual DbSet<MAS_FoodType> MAS_FoodType { get; set; }
        public virtual DbSet<MAS_MealPack> MAS_MealPack { get; set; }
        public virtual DbSet<MAS_OrderStatus> MAS_OrderStatus { get; set; }
        public virtual DbSet<MAS_OrderType> MAS_OrderType { get; set; }
        public virtual DbSet<MAS_PaymentType> MAS_PaymentType { get; set; }
        public virtual DbSet<MAS_Price> MAS_Price { get; set; }
        public virtual DbSet<MAS_Role> MAS_Role { get; set; }
        public virtual DbSet<TRN_ChefDetails> TRN_ChefDetails { get; set; }
        public virtual DbSet<TRN_ChefOrder> TRN_ChefOrder { get; set; }
        public virtual DbSet<TRN_ChefOtherDetails> TRN_ChefOtherDetails { get; set; }
        public virtual DbSet<TRN_DeliveryDetails> TRN_DeliveryDetails { get; set; }
        public virtual DbSet<TRN_LoginDetail> TRN_LoginDetail { get; set; }
        public virtual DbSet<TRN_MapOrderToChef> TRN_MapOrderToChef { get; set; }
        public virtual DbSet<TRN_MealPackMapping> TRN_MealPackMapping { get; set; }
        public virtual DbSet<TRN_MealPackProcessing> TRN_MealPackProcessing { get; set; }
        public virtual DbSet<TRN_Order> TRN_Order { get; set; }
        public virtual DbSet<TRN_OrderAppliedDiscount> TRN_OrderAppliedDiscount { get; set; }
        public virtual DbSet<TRN_OrderDetails> TRN_OrderDetails { get; set; }
        public virtual DbSet<TRN_SpecialDiscount> TRN_SpecialDiscount { get; set; }
        public virtual DbSet<TRN_UserAddressDetails> TRN_UserAddressDetails { get; set; }
        public virtual DbSet<TRN_UserDetail> TRN_UserDetail { get; set; }

        private readonly string _dbName= "Server=DESKTOP-2F4H19O\\SQLEXPRESS;Database=homefood3;persist security info=True;MultipleActiveResultSets=True;User ID=sqlLogin;Password=neeyamo@123";

        public HomeFoodEntities(DbContextOptions<HomeFoodEntities> options) : base(options)
        {
            
        }

        public HomeFoodEntities(string dbName)
        {
            _dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!string.IsNullOrEmpty(_dbName))
                optionsBuilder.UseSqlServer(_dbName);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new AlbumConfiguration(modelBuilder.Entity<Album>());
            //new ArtistConfiguration(modelBuilder.Entity<Artist>());
            new CustomerConfiguration(modelBuilder.Entity<Customer>());
            //new EmployeeConfiguration(modelBuilder.Entity<Employee>());
            //new GenreConfiguration(modelBuilder.Entity<Genre>());
            //new InvoiceConfiguration(modelBuilder.Entity<Invoice>());
            //new InvoiceLineConfiguration(modelBuilder.Entity<InvoiceLine>());
            //new MediaTypeConfiguration(modelBuilder.Entity<MediaType>());
            //new PlaylistConfiguration(modelBuilder.Entity<Playlist>());
            //new PlaylistTrackConfiguration(modelBuilder.Entity<PlaylistTrack>());
            //new TrackConfiguration(modelBuilder.Entity<Track>());
        }
    }
}