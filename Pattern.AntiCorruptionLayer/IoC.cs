namespace Pattern.AntiCorruptionLayer
{
    using Adapters;

    using Domain.Dogs;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Specifications;

    using Transforms;

    public static class IoC
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Repository.IoC.ConfigureServices(services, configuration);

            services.AddTransient<DogsSpecification>();

            services.AddTransient<AnimalToDogTransform>();
            services.AddTransient<AnimalToHyenaTransform>();
            services.AddTransient<NewDogToAnimalTransform>();
            services.AddTransient<DogToAnimalTransform>();

            services.AddTransient<IDogAdapter, DogAdapter>();

            return services;
        }
    }
}