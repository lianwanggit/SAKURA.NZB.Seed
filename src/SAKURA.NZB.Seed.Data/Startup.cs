using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SAKURA.NZB.Seed.Data
{
	/// <summary>
	/// For dotnet ef command line
	/// </summary>
	public class Startup
    {
		public static void Main(string[] args)
		{
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddEntityFrameworkSqlServer()
				.AddDbContext<NZBContext>(options => options.UseSqlServer("Server=LEMO-PC;Database=NZB-Seed;Trusted_Connection=True;MultipleActiveResultSets=true"));
		}

		public void Configure()
		{
		}
	}
}
