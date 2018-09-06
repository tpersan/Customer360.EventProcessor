using System.Threading.Tasks;

namespace Customer360.Legacy.Entities.Repository
{
    public interface IRegistrationDataRepository
    {
        Task<RegistrationData> GetByAsync(long customerDocument);
    }
}
