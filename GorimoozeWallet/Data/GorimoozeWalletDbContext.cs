using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using GorimoozeWallet.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace GorimoozeWallet.Data
{
    public class GorimoozeWalletDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>, IGorimoozeWalletDbContext
    {
        public GorimoozeWalletDbContext(DbContextOptions<GorimoozeWalletDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
                .HasOne(c => c.Currency)
                .WithMany(p => p.Wallets)
                .HasForeignKey(c => c.CurrencyId);

            modelBuilder.Entity<Wallet>()
                .HasOne(c => c.Portfolio)
                .WithMany(p => p.Wallets)
                .HasForeignKey(c => c.PortfolioId);

            modelBuilder.Entity<IdentityUserLogin<long>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<long>>().HasNoKey();
            //modelBuilder.Entity<IdentityUserClaim<long>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<long>>().HasNoKey();
        }
    }
}
