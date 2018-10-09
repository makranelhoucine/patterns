namespace Pattern.AntiCorruptionLayer
{
    using Adapters;

    using Domain.Dogs;
    using Domain.DogsAndHyenas;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Specifications;

    using Transforms;

    public static class IoC
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Repository.IoC.ConfigureServices(services, configuration);

            services.AddSingleton<DogsSpecification>()
                    .AddSingleton<HyenaSpecification>()
                    .AddSingleton<AnimalToDogTransform>()
                    .AddSingleton<AnimalToHyenaTransform>()
                    .AddSingleton<NewDogToAnimalTransform>()
                    .AddSingleton<DogToAnimalTransform>()
                    .AddSingleton<AnimalToAnimalModelTransform>();

            services.AddTransient<IDogAdapter, DogAdapter>()
                    .AddTransient<IDogsAndHyenasAdapter, DogsAndHyenasAdapter>();

            return services;
        }
    }
}