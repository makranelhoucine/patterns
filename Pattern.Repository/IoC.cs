namespace Pattern.Repository
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPatternContext>(
                _ => new PatternContext(configuration.GetConnectionString(nameof(PatternContext))));

            services.AddTransient(typeof(IReader<>), typeof(Reader<>));
            services.AddTransient(typeof(IWriter<>), typeof(Writer<>));

            return services;
        }
    }
}