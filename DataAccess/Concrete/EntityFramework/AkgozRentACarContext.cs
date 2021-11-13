using Core.Entities.Concrete;
using Entity.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AkgozRentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-DR7EADTJ\SQLEXPRESS;Initial Catalog=RentACarDb;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<CarInfo> CarInfos { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }


    }
}