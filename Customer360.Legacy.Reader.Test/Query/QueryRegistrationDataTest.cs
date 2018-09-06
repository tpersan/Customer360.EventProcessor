using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Customer360.Legacy.Reader.Query;
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
        }
    }
}
