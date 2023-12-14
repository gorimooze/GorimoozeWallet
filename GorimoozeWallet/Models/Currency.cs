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

        //public string? ImageName { get; set; } 
        //public byte[]? ImageData { get; set; } 

        public ICollection<Wallet> Wallets { get; set; }
    }
}
