using Microsoft.Extensions.Configuration;

namespace TestProject
{
    public class ConfigData
    {
        public IConfigurationRoot GetConfigurationBuilder()
        {
            return new ConfigurationBuilder()
            .AddJsonFile(@"D:\Training\FinalProject\Rdklu\Config\projectData.json")
            .Build();
        }
    }
}