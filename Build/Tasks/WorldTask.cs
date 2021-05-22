using System.Threading.Tasks;
using Cake.Core.Diagnostics;
using Cake.Frosting;

namespace Build.Tasks
{
    [TaskName("World")]
    [IsDependentOn(typeof(HelloTask))]
    public sealed class WorldTask : AsyncFrostingTask<BuildContext>
    {
        // Tasks can be asynchronous
        public override async Task RunAsync(BuildContext context)
        {
            if (context.Delay)
            {
                context.Log.Information("Waiting...");
                await Task.Delay(context.DelayMilliseconds);
            }

            context.Log.Information("World");
        }
    }
}