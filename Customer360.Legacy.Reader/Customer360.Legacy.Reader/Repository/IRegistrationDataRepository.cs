using System.Threading.Tasks;
using Customer360.Legacy.Reader.Contract;

namespace Customer360.Legacy.Reader.Repository
{
    public interface IRegistrationDataRepository
    {
        Task<RegistrationData> GetByAsync(long customerDocument);
    }
}
