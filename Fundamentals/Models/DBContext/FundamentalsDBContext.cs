using System.Configuration;
using System.Data.Entity;
using System.Reflection;
using Fundamentals.Models.Authorization;
using Fundamentals.Models.Movies;

namespace Fundamentals.Models.FundamentalsDBContext
{
    public class FundamentalsDBContext : DbContext
    {
        private static readonly string _connectionString;

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

        public DbSet<UserViewModel> MemberTypes { get; set; }

        public DbSet<Ganres> Ganres { get; set; }

        public DbSet<File> Files { get; set; }
    }
}