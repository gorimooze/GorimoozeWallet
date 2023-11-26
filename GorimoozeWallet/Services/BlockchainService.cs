using System.Security.Cryptography;
using System.Text;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Services
{
    public class BlockchainService : IBlockchainService
    {

        private string CalculateHash(List<Transaction> transactions, string previousHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var transactionData = string.Join(",", transactions.Select(t => $"{t.SenderWalletId}-{t.RecipientWalletId}-{t.Amount}"));
                var rawData = $"{DateTime.Now}-{transactionData}-{previousHash}";
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
