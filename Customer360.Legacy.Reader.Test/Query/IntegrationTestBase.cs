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
            serviceCollection.AddUnitOfWorkDapper(opt => opt.AddConnection<SqlConnection>(configuration.GetConnectionString("SQLServerConnection")));

            //serviceCollection.AddTransient<ApiMappers>();
            //serviceCollection.AddTransient<ResgateBusiness>();

            services = serviceCollection.BuildServiceProvider();

        }

        public T GetService<T>()
        {
            return services.GetService<T>();
        }

        public void Setup()
        {
            context = services.GetService<DapperContext>();
            context.BeginTransaction();

            dataAccess = services.GetService<DataAccess>();
        }

    }
}