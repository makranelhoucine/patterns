namespace Sample.App
{
    using System;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Pattern.AntiCorruptionLayer;
    using Pattern.Domain.Dogs;
    using Pattern.NullObject.Models;

    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Configure();
            var logger = serviceProvider.GetService<ILoggerFactory>()
                                        .CreateLogger<Program>();

            var getDogs = serviceProvider.GetService<GetDogs>();
            getDogs.Execute(
                dogs =>
                    {
                        foreach (Dog dog in dogs)
                        {
                            logger.LogInformation(dog.Describe());
                        }
                    });

            Console.ReadKey();
        }

        private static ServiceProvider Configure()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var serviceCollection = new ServiceCollection().AddLogging();
            IoC.ConfigureServices(serviceCollection, configuration);
            Pattern.Domain.IoC.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<ILoggerFactory>().AddConsole();
            return serviceProvider;
        }
    }
}