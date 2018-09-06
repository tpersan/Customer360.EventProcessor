using System.Threading.Tasks;
using Customer360.Legacy.Entities;
using Customer360.Legacy.Entities.Repository;

namespace Customer360.Legacy.Reader.Dao
{
    public class RegistrationDataRepository : IRegistrationDataRepository
    {
        public Task<RegistrationData> GetBy(long customerDocument)
        {
            throw new System.NotImplementedException();
        }
    }
}
