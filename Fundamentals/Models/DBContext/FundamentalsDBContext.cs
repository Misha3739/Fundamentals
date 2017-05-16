using System.Configuration;
using System.Data.Entity;
using Fundamentals.DomainModel;
using Fundamentals.Models.Authorization;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fundamentals.Models.DBContext
{
    public class FundamentalsDBContext : IdentityDbContext<ApplicationUser>
    {
        private static readonly string _connectionString;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<FundamentalsDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public static FundamentalsDBContext Create()
        {
            return new FundamentalsDBContext();
        }

        static FundamentalsDBContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[nameof(FundamentalsDBContext)].ConnectionString;
        }

        public FundamentalsDBContext() :
            base(_connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FundamentalsDBContext>());

        }


        public FundamentalsDBContext(string connectionstring) : 
           this()
        {
            
        }

        public DbSet<CustomerViewModel> Customers { get; set; }

        public DbSet<MovieViewModel> Movies { get; set; }

       

        public DbSet<Ganres> Ganres { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<ClaimRoles> ClaimRoles { get; set; }

    }
}