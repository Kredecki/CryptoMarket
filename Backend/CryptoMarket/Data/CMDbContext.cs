using CryptoMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CryptoMarket.Data
{
    public class CMDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        readonly DbContextOptions<CMDbContext> options;
        public CMDbContext(DbContextOptions<CMDbContext> _options) : base(_options)
        {
            this.options = _options;
        }

        public virtual DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
