using System.Threading.Tasks;
using Api.Infraestrutura.Core.Dapper;
using Customer360.Legacy.Reader.Contract;
using Customer360.Legacy.Reader.Query;
using Customer360.Legacy.Reader.Repository;

namespace Customer360.Legacy.Reader.Dao
{
    public class RegistrationDataRepository : IRegistrationDataRepository
    {
        private readonly DataAccess _dataAccess;

        public RegistrationDataRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<RegistrationData> GetByAsync(long customerDocument)
        {
            return await _dataAccess.ExecuteAsync(new QueryRegistrationData(customerDocument));
        }
    }
}
