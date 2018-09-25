using System.Data.SqlClient;
using System.Threading.Tasks;
using Api.Infraestrutura.Core.Dapper;
using Api.Infraestrutura.Core.Dapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer360.Legacy.Reader.Test.Query
{
    public class IntegrationTestBase
    {

        public ServiceProvider services;
        public DapperContext context;
        public DataAccess dataAccess;

        private IConfiguration _configuration;
        public IConfiguration configuration => _configuration ?? (_configuration = IniciarConfiguration());

        public IntegrationTestBase()
        {
            OneTimeSetUp();
        }

        public void OneTimeSetUp()
        {
            ConfigurarServicos();
            //ApiMappers.Configure();
        }

        public static IConfiguration IniciarConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return config;
        }

        private void ConfigurarServicos()
        {
            var serviceCollection = new ServiceCollection();

            var connectionString = configuration.GetConnectionString("mongeral.legacy.sqlserverconnection");
            serviceCollection.AddUnitOfWorkDapper(opt => opt.AddConnection<SqlConnection>(connectionString));

            services = serviceCollection.BuildServiceProvider();
            Setup();

        }

        public T GetService<T>()
        {
            return services.GetService<T>();
        }

        public void Setup()
        {
            context = services.GetService<DapperContext>();
            dataAccess = services.GetService<DataAccess>();
        }

    }
}