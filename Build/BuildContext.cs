using Cake.Core;
using Cake.Frosting;

namespace Build
{
    public class BuildContext : FrostingContext
    {
        public bool Delay { get; set; }
        public int DelayMilliseconds { get; set; }

        public BuildContext(ICakeContext context) : base(context)
        {
            Delay = context.Arguments.HasArgument("delay");
            DelayMilliseconds = int.Parse(context.Arguments.GetArgument("delay"));
        }
    }
}