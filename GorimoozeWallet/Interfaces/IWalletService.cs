﻿using GorimoozeWallet.Dto;

namespace GorimoozeWallet.Interfaces
{
    public interface IWalletService
    {
        ICollection<WalletDto> GetWalletList();
        WalletDto GetWalletById(long id);
        WalletDto GetWalletByUserId(long userId);
        void Create(WalletDto wallet);
        void Update(WalletDto wallet);
        void Delete(long id);
    }
}