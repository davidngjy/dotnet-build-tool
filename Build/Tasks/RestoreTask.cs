using System;
using System.Linq;
using Build.Contexts;
using Build.Model;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Restore;
using Cake.Frosting;
using Spectre.Console;

namespace Build.Tasks
{
	[TaskName("Restore NuGet Packages")]
	[IsDependentOn(typeof(CleanTask))]
	public class RestoreTask : FrostingTask<Context>
	{
		private readonly IProjectDiscoverer _projectDiscoverer;

		public RestoreTask(IProjectDiscoverer projectDiscoverer) => _projectDiscoverer = projectDiscoverer;

		public override void Run(Context context)
		{
			_projectDiscoverer
				.GetAllProjects()
				.AsParallel()
				.ForAll(project => RestoreProjectWithExceptionHandling(context, project));
		}

		private void RestoreProjectWithExceptionHandling(Context context, Project project)
		{
			try
			{
				context.DotNetCoreRestore(project.AbsolutePath, new DotNetCoreRestoreSettings
				{
					Verbosity = DotNetCoreVerbosity.Quiet
				});

				AnsiConsole.MarkupLine($"Restored {project.ProjectName}. :check_mark:");
			}
			catch (Exception)
			{
				AnsiConsole.MarkupLine($"Failed {project.ProjectName}. :cross_mark:");
			}
		}
	}
}
