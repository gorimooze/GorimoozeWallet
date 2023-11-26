namespace GorimoozeWallet.Models
{
    public class Block
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public long TransactionId { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
    }
}
