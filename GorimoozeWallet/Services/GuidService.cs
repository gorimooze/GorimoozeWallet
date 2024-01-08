using GorimoozeWallet.Interfaces;

namespace GorimoozeWallet.Services
{
    public class GuidService : IGuidService
    {
        public Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
