namespace GorimoozeWallet.Dto.pages
{
    public class ProfileDto
    {
        public long PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public long? WalletId { get; set; }
        public double? Score { get; set; }
        public string CurrencyName { get; set; }
    }
}
