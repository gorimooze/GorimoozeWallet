using GorimoozeWallet.Data;
using GorimoozeWallet.Dto;
using GorimoozeWallet.Interfaces;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Services
{
    public class UserService : IUserService
    {
        private readonly IGorimoozeWalletDbContext _context;

        public UserService(IGorimoozeWalletDbContext context)
        {
            _context = context;
        }

        public ICollection<UserDto> GetAllUsers()
        {
            return _context.User_GetAllUsers();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(User model)
        {
            throw new NotImplementedException();
        }

        public void Update(User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(User model)
        {
            throw new NotImplementedException();
        }
    }
}
