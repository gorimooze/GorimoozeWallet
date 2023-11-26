using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GorimoozeWallet.Models
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string UniqueNumber { get; set; }

        public User UserId { get; set; }

        public Currency CurrencyId { get; set; }

        public decimal? Score { get; set; }

        public bool? IsLocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
