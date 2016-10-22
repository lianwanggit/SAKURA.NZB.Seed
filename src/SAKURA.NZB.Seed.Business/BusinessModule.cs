using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SAKURA.NZB.Seed.Business.Extensions;

namespace SAKURA.NZB.Seed.Business
{
	public class BusinessModule
    {
		private readonly IConfigurationRoot _config;

		public BusinessModule(IConfigurationRoot config)
        {
			_config = config;
        }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDatabase(_config)
				.AddMediator();
		}

	}
}
