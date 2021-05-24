using Cake.Frosting;

namespace Build.Tasks
{
    [TaskName("Default")]
    [IsDependentOn(typeof(UnitTestTask))]
    public class DefaultTask : FrostingTask
    {
    }
}