using GorimoozeWallet.Dto.pages;

namespace GorimoozeWallet.Interfaces.pages
{
    public interface IPageService
    {
        IList<ProfileDto> Profile_GetByUserId(long userId);
    }
}
