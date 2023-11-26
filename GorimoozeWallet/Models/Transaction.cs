namespace GorimoozeWallet.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string SenderWalletId { get; set; }
        public string RecipientWalletId { get; set; }
        public decimal Amount { get; set; }
    }
}
