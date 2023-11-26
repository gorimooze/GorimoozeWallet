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
    }
}
