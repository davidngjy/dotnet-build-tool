using Cake.Frosting;

namespace Build
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            return new CakeHost()
                .UseContext<BuildContext>()
                .ConfigureServices(serviceCollection => serviceCollection.RegisterServices())
                .Run(args);
        }
    }
}
