namespace GorimoozeWallet.Dto
{
    public class PortfolioDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public long UserId { get; set; }
    }
}
