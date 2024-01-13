using GorimoozeWallet.Models;

namespace GorimoozeWallet.Dto
{
    public class WalletDto
    {
        public long Id { get; set; }
        public string WalletNumber { get; set; }
        public bool IsLocked { get; set; }
        public double Score { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CurrencyId { get; set; }
        public long PortfolioId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
