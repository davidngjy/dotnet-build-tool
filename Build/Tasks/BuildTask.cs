using System;
using System.Linq;
using Build.Contexts;
using Build.Model;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Common.Tools.DotNetCore.MSBuild;
using Cake.Frosting;
using Spectre.Console;

namespace Build.Tasks
{
	[TaskName("Build Projects")]
	[IsDependentOn(typeof(RestoreTask))]
	public class BuildTask : FrostingTask<Context>
	{
		private readonly IProjectDiscoverer _projectDiscoverer;

		public BuildTask(IProjectDiscoverer projectDiscoverer) => _projectDiscoverer = projectDiscoverer;
		
		public override void Run(Context context)
		{
			_projectDiscoverer
				.GetAllProjects()
				.AsParallel()
				.ForAll(project => BuildProjectWithExceptionHandling(context, project));
		}

		private void BuildProjectWithExceptionHandling(Context context, Project project)
		{
			try
			{
				context.DotNetCoreBuild(project.AbsolutePath, new DotNetCoreBuildSettings
				{
					Configuration = context.MsBuildConfiguration,
					NoLogo = true,
					Verbosity = DotNetCoreVerbosity.Quiet,
					MSBuildSettings = new DotNetCoreMSBuildSettings
					{
						ConsoleLoggerSettings = new MSBuildLoggerSettings
						{
							NoSummary = true,
						},
					},
					NoRestore = true
				});

				AnsiConsole.MarkupLine($"Built {project.ProjectName}. :check_mark:");
			}
			catch (Exception)
			{
				AnsiConsole.MarkupLine($"Failed {project.ProjectName}. :cross_mark:");
			}
		}
	}
}
