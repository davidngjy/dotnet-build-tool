using Build.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Build
{
	public static class Bindings
	{
		public static void RegisterServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IProjectDiscoverer, ProjectDiscoverer>();
		}
	}
}
