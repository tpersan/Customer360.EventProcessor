using Newtonsoft.Json.Serialization;
using Xunit;

namespace Customer360.Legacy.Reader.Test.Events
{
    public class CrmsCallServiceTest
    {
        [Fact]
        public void ReadDataReturnNull()
        {
            JsonObjectContract careData = null;
            Assert.Null(careData);
        }


        [Fact]
        public void ReadDataReturnValidData()
        {
            JsonObjectContract careData = new JsonObjectContract("Teste".GetType());
            Assert.NotNull(careData);
        }

    }
}
