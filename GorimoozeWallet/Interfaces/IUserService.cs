using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Interfaces
{
    public interface IUserService
    {
        ICollection<UserDto> GetAllUsers();
        User GetUserById(int id);
        void Create(User model);
        void Update(User model);
        void Delete(User model);
    }
}
