using System;
using System.Text;
using Build.Contexts;
using Cake.Frosting;

namespace Build
{
    public static class Program
    {
        public static int Main(string[] args)
        {
	        Console.OutputEncoding = Encoding.UTF8;

            return new CakeHost()
                .UseContext<Context>()
                .ConfigureServices(serviceCollection => serviceCollection.RegisterServices())
                .Run(args);
        }
    }
}
