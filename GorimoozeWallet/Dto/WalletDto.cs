using GorimoozeWallet.Models;

namespace GorimoozeWallet.Dto
{
    public class WalletDto
    {
        public long Id { get; set; }

        public string WalletNumber { get; set; }

        public long UserId { get; set; }

        public bool? IsLocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
