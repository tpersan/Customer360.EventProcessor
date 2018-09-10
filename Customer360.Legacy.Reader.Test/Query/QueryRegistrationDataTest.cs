using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer360.Legacy.Reader.Query;
using Customer360.Legacy.Reader.Test.Query;
using Xunit;

namespace Customer360.Legacy.Reader.Test.Query
{
    public class QueryRegistrationDataTest : IntegrationTestBase
    {

        [Fact]
        public async Task TestLegacyValidData()
        {
            long customerDocument = 9122368760;

            var consulta = new QueryRegistrationData(customerDocument);

            var resultado = await dataAccess.ExecuteAsync(consulta);

            Assert.NotNull(resultado);
            Assert.True(resultado.CustomerDocument == customerDocument);
            Assert.True(resultado.BornDate == new DateTime(1982, 09, 25));

            Assert.True(resultado.Addresses.Any());
            Assert.Contains(resultado.Addresses, a => a.StreetAddress.ToLowerInvariant().Contains("pires"));

        }
    }
}
