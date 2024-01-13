using GorimoozeWallet.Dto;
using GorimoozeWallet.Models;

namespace GorimoozeWallet.Interfaces
{
    public interface IWalletService
    {
        ICollection<Wallet> GetList();
        bool Exists(long walletId);
        WalletDto GetById(long walletId);
        ICollection<Wallet> GetListByUserId(long userId);
        void Create(WalletDto walletDto);
        void Update(long walletId, WalletDto walletDto);
        void Delete(long walletId);
    }
}
