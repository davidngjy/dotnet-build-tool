using Cake.Common;
using Cake.Core;
using Cake.Frosting;

namespace Build.Contexts
{
    public class Context : FrostingContext
    {
        public string MsBuildConfiguration { get; }

        public Context(ICakeContext context) : base(context)
        {
            MsBuildConfiguration = context.Argument("configuration", "Debug");
        }
    }
}