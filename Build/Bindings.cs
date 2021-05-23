using Build.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Build
{
	public static class Bindings
	{
		public static void RegisterServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IProjectFileHandler, ProjectFileHandler>();
		}
	}
}
