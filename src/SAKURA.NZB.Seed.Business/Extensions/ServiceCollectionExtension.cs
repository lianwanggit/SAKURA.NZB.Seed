using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAKURA.NZB.Seed.Data;
using Scrutor;
using System;
using System.Collections.Generic;

namespace SAKURA.NZB.Seed.Business.Extensions
{
	public static class ServiceCollectionExtension
    {
		public static IServiceCollection AddDatabase(this IServiceCollection services, IConfigurationRoot config)
		{
			return services
				.AddEntityFrameworkSqlServer()
				.AddDbContext<NZBContext>(options => options.UseSqlServer(config["connectionString"]))
				.AddHangfire(configuration => 
					configuration.UseSqlServerStorage(config["connectionString"]));
		}

		public static IServiceCollection AddMediator(this IServiceCollection services)
		{
			services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
			services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

			services.Scan(scan => scan
			  .FromAssembliesOf(typeof(IMediator), typeof(BusinessModule))
			  .AddClasses()
			  .AsImplementedInterfaces());

			return services;
		}

		private static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
		{
			return (IEnumerable<object>)provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
		}
	}
}
