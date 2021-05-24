using Cake.Common.Tools.DotNetCore;
using Cake.Frosting;
using System;
using System.Linq;
using Build.Contexts;
using Build.Model;
using Cake.Common.Tools.DotNetCore.Clean;
using Spectre.Console;

namespace Build.Tasks
{
	[TaskName("Clean Build Artifacts")]
	public class CleanTask : FrostingTask<Context>
	{
		private readonly IProjectDiscoverer _projectDiscoverer;

		public CleanTask(IProjectDiscoverer projectDiscoverer) => _projectDiscoverer = projectDiscoverer;

		public override void Run(Context context)
		{
			_projectDiscoverer
				.GetAllProjects()
				.AsParallel()
				.ForAll(project => CleanProjectArtifactWithExceptionHandling(context, project));
		}

		private void CleanProjectArtifactWithExceptionHandling(Context context, Project project)
		{
			try
			{
				context.DotNetCoreClean(project.AbsolutePath, new DotNetCoreCleanSettings
				{
					Verbosity = DotNetCoreVerbosity.Quiet,
					NoLogo = true
				});

				AnsiConsole.MarkupLine($"Cleaned {project.ProjectName}. :check_mark:");
			}
			catch (Exception)
			{
				AnsiConsole.MarkupLine($"Failed {project.ProjectName}. :cross_mark:");
			}
		}
	}
}
