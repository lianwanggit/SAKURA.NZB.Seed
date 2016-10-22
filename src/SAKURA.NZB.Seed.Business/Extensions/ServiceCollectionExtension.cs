using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAKURA.NZB.Seed.Data;

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
	}
}
