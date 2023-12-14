using GorimoozeWallet.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GorimoozeWallet.Services.Identity
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
    }
}
