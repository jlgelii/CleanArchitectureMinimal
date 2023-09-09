namespace CleanArchitecture.API.Configurations.Services
{
    public static class ConfigurationServiceExtensions
    {
        public static IConfigurationBuilder AppSettingConfigurations(this IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            var config = builder.AddJsonFile("appsettings.json")
                                .Build();
            var env = config.GetValue("Env", "string");

            builder.AddJsonFile("appsettings.json", false, true)
                   .AddJsonFile($"appsettings.{env}.json", false, true)
                   .AddEnvironmentVariables();

            return builder;
        }
    }
}
