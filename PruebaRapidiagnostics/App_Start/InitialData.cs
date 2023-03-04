using Microsoft.Extensions.DependencyInjection;
using PruebaRapidiagnostics.ApplicationCore.Consts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PruebaRapidiagnostics
{
    public class InitialData
    {
        public static void Start()
        {
            string DataSource = ConfigurationManager.AppSettings["DataSource"];
            string InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"];
            string UserId = ConfigurationManager.AppSettings["UserId"];
            string Password = ConfigurationManager.AppSettings["Password"];

            //GlobalSettings.ConnectionString = $"Server={DataSource};Database={InitialCatalog};User Id={UserId};Password={Password};TrustServerCertificate=True";

            GlobalSettings.ConnectionString = $"Server={DataSource};Database={InitialCatalog};User Id={UserId};Password={Password};TrustServerCertificate=True";
            if (GlobalSettings.ConnectionString == null) throw new Exception("Cadena de conexión inválida");

            //IServiceCollection serviceCollection = new ServiceCollection();

            ////Registramos el DbContext
            ////serviceCollection.AddDbContext<EFContext>(options => options.UseMySql(GlobalSettings.ConnectionString));

            //serviceCollection.AddSingleton<IProductoRepository, ProductoRepository>();
            //serviceCollection.AddSingleton<IProductoService, ProductoService>();

            ////Construimos el contendor IoC
            //var services = serviceCollection.BuildServiceProvider();


        }
    }
}