using GorimoozeWallet.Helper.Interfaces;

namespace GorimoozeWallet.Helper.Extensions
{
    public class GuidService : IGuidService
    {
        public Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
