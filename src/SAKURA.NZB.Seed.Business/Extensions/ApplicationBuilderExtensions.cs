using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SAKURA.NZB.Seed.Data;

namespace SAKURA.NZB.Seed.Business.Extensions
{
    public static class ApplicationBuilderExtensions
    {
		public static IApplicationBuilder EnsureDatabase(this IApplicationBuilder app)
		{
			var services = app.ApplicationServices;
			services.GetService<NZBContext>().Database.Migrate();

			return app;
		}
	}
}
