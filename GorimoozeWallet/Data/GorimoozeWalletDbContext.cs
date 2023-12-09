using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GorimoozeWallet.Data
{
    public class GorimoozeWalletDbContext : DbContext, IGorimoozeWalletDbContext
    {
        public GorimoozeWalletDbContext(DbContextOptions<GorimoozeWalletDbContext> options) : base(options) 
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
                .HasKey(w => new { w.UserId });
            //modelBuilder.Entity<Wallet>()
            //    .HasOne(w => w.User)
            //    .WithMany(u => u.Wallets)
            //    .HasForeignKey(w => w.UserId);
            //modelBuilder.Entity<Wallet>()
            //    .HasOne(w => w.Currency)
            //    .WithMany(c => c.Wallets)
            //    .HasForeignKey(w => w.CurrencyId);
        }



        public ICollection<UserDto> User_GetAllUsers()
        {
            return Database.SqlQueryRaw<UserDto>("EXEC [dbo].[User_GetAllUsers]").ToList();
        }

        public ICollection<CurrencyDto> Currency_GetAllCurrency()
        {
            return Database.SqlQueryRaw<CurrencyDto>("EXEC [dbo].[Currency_GetAllCurrency]").ToList();
        }

        public CurrencyDto Currency_GetById(long id)
        {
            // For avoiding sql injections
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.BigInt) { Value = id }
            };

            return Database.SqlQueryRaw<CurrencyDto>("EXEC [dbo].[Currency_GetById] {0}", parameters).FirstOrDefault();
        }

        public void Currency_CreateOrUpdateOrDelete(CurrencyDto currency)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.NVarChar) { Value = currency.Id },
                new SqlParameter("@name", SqlDbType.NVarChar) { Value = currency.Name },
                new SqlParameter("@shortName", SqlDbType.NVarChar) { Value = currency.ShortName },
                new SqlParameter("@stateActivity", SqlDbType.Int) { Value = currency.StateActivity },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = currency.IsActive },
                new SqlParameter("@isDeleted", SqlDbType.Bit) { Value = currency.IsDeleted },
                new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = currency.ImageName },
                new SqlParameter("@imageData", SqlDbType.VarBinary) { Value = currency.ImageData },
                
            };

            Database.ExecuteSqlRaw("EXEC [dbo].[Currency_CreateOrUpdateOrDelete] {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", parameters);
        }

        public ICollection<WalletDto> Wallet_GetAll()
        {
            return Database.SqlQueryRaw<WalletDto>("EXEC [dbo].[Wallet_GetAll]").ToList();
        }

        public WalletDto Wallet_GetByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public void Wallet_CreateOrUpdateOrDelete(WalletDto wallet)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.BigInt) { Value = wallet.Id },
                new SqlParameter("@uniqueNumber", SqlDbType.NVarChar) { Value = wallet.WalletNumber },
                new SqlParameter("@userId", SqlDbType.BigInt) { Value = wallet.UserId },
                new SqlParameter("@isLocked", SqlDbType.Bit) { Value = wallet.IsLocked },
                new SqlParameter("@createdOn", SqlDbType.DateTime) { Value = wallet.CreatedOn },
                new SqlParameter("@isDeleted", SqlDbType.Bit) { Value = wallet.IsDeleted }
            };

            Database.SqlQueryRaw<WalletDto>("EXEC [dbo].[Wallet_CreateOrUpdateOrDelete] {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", parameters);
        }

        public ICollection<PortfolioDto> Portfolio_GetGetPortfoliosByWallet(string guidWallet)
        {
            throw new NotImplementedException();
        }
    }
}
