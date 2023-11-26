using System.ComponentModel.DataAnnotations;

namespace GorimoozeWallet.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
