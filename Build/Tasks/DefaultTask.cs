using Build.Handlers;
using Cake.Core;
using Cake.Frosting;

namespace Build.Tasks
{
    [TaskName("Default")]
    [IsDependentOn(typeof(CleanTask))]
    public class DefaultTask : FrostingTask
    {
    }
}