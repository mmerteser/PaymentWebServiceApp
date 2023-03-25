using Microsoft.Extensions.Configuration;

namespace Onix.Persistence
{
    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Onix.WebApi"));
                    configurationManager.AddJsonFile("appsettings.Development.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.json");
                }

                return configurationManager.GetConnectionString("ApplicationSQL");
            }
        }
    }
}
