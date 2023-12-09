namespace GorimoozeWallet.Models
{
    public class Portfolio
    {
        public long Id { get; set; }
        public long CurrencyId { get; set; }
        public long WalletId { get; set; }
        public bool IsActive { get; set; }
        public double Score { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
