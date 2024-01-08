using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GorimoozeWallet.Models
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string WalletNumber { get; set; }

        public bool IsLocked { get; set; }

        public double Score { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CurrencyId { get; set; }
        public long PortfolioId { get; set; }

        public Currency Currency { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
