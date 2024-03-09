using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using GorimoozeWallet.Data.Entities;
using GorimoozeWallet.Dto.pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace GorimoozeWallet.Data
{
    public class GorimoozeWalletDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public GorimoozeWalletDbContext(DbContextOptions<GorimoozeWalletDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }

        //private DbSet<ProfileDto> ProfileDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wallet>()
                .HasOne(c => c.Currency)
                .WithMany(p => p.Wallets)
                .HasForeignKey(c => c.CurrencyId);

            modelBuilder.Entity<Wallet>()
                .HasOne(c => c.Portfolio)
                .WithMany(p => p.Wallets)
                .HasForeignKey(c => c.PortfolioId);

            //modelBuilder.Entity<ProfileDto>().HasNoKey().ToView(null);
        }

        //public IList<ProfileDto> Profile_GetByUserId(long userId)
        //{
            
        //    var result = ProfileDto.FromSqlRaw("exec [dbo].[Profile_GetByUserId] @userId", new SqlParameter("@userId", userId)).ToList();
        //    return result;
        //}
    }
}
