using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GorimoozeWallet.Models
{
    public class Order 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime? CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
