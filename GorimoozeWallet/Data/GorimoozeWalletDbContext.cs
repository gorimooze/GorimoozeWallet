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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>()
                .HasKey(w => new { w.UserId, w.CurrencyId });
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

            return Database.SqlQueryRaw<CurrencyDto>("EXEC [dbo].[Currency_GetAllCurrency] {0}", parameters).FirstOrDefault();
        }

        public void Currency_CreateOrUpdateOrDelete(CurrencyDto currency)
        {
            var parameters = new[]
            {
                new SqlParameter("@name", SqlDbType.NVarChar) { Value = currency.Name },
                new SqlParameter("@shortName", SqlDbType.NVarChar) { Value = currency.ShortName },
                new SqlParameter("@stateActivity", SqlDbType.Int) { Value = currency.StateActivity },
                new SqlParameter("@isActive", SqlDbType.Bit) { Value = currency.IsActive },
                new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = currency.ImageName },
                new SqlParameter("@imageData", SqlDbType.VarBinary) { Value = currency.ImageData },
            };

            Database.ExecuteSqlRaw("EXEC [dbo].[Currency_GetAllCurrency] {0}, {1}, {2}, {3}, {4}, {5}", parameters);
        }

        public ICollection<WalletDto> Wallet_GetAll()
        {
            return Database.SqlQueryRaw<WalletDto>("EXEC [dbo].[Wallet_GetAll]").ToList();
        }

        public WalletDto Wallet_GetById(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.BigInt) { Value = id }
            };

            return Database.SqlQueryRaw<WalletDto>("EXEC [dbo].[Wallet_GetById] {0}", parameters).FirstOrDefault();
        }

        public void Wallet_CreateOrUpdate(WalletDto wallet)
        {
            var parameters = new[]
            {
                new SqlParameter("@uniqueNumber", SqlDbType.NVarChar) { Value = wallet.UniqueNumber },
                new SqlParameter("@userId", SqlDbType.BigInt) { Value = wallet.UserId },
                new SqlParameter("@currencyId", SqlDbType.BigInt) { Value = wallet.CurrencyId },
                new SqlParameter("@score", SqlDbType.Float) { Value = wallet.Score },
                new SqlParameter("@isLocked", SqlDbType.Bit) { Value = wallet.IsLocked },
                new SqlParameter("@createdOn", SqlDbType.DateTime) { Value = wallet.CreatedOn },
                new SqlParameter("@isDeleted", SqlDbType.Bit) { Value = wallet.IsDeleted }
            };

            Database.SqlQueryRaw<WalletDto>("EXEC [dbo].[Wallet_GetById] {0}", parameters);
        }

        public void Wallet_Delete(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", SqlDbType.BigInt) { Value = id }
            };

            Database.SqlQueryRaw<WalletDto>("EXEC [dbo].[Wallet_Delete] {0}", parameters);
        }
    }
}
