using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GorimoozeWallet.Enums;

namespace GorimoozeWallet.Models
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        public CurrencyStateActivityEnum StateActivity { get; set; }

        public bool? IsActive { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
    }
}
