using Cake.Frosting;

namespace Build.Tasks
{
    [TaskName("Default")]
    [IsDependentOn(typeof(WorldTask))]
    public class DefaultTask : FrostingTask
    {
    }
}