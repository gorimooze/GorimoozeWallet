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

        public long UserId { get; set; }

        public bool? IsLocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public User User { get; set; }

        public Currency Currency { get; set; }
    }
}
