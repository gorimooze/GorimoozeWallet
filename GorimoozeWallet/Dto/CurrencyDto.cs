using GorimoozeWallet.Enums;
using System.ComponentModel.DataAnnotations;

namespace GorimoozeWallet.Dto
{
    public class CurrencyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public CurrencyStateActivityEnum StateActivity { get; set; }
        public bool IsActive { get; set; }
        //public string ImageName { get; set; } 
        //public byte[] ImageData { get; set; } 
    }
}
