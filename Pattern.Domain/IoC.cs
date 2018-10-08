﻿namespace Pattern.Domain
{
    using Dogs;

    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CreateDog>()
                             .AddTransient<GetDog>()
                             .AddTransient<GetDogs>()
                             .AddTransient<UpdateDog>();
            return serviceCollection;
        }
    }
}