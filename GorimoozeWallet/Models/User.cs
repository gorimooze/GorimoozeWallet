using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GorimoozeWallet.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public long? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Password { get; set; }

        public DateTime? CreatedOn { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
    }
}
