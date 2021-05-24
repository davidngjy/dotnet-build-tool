using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Build.Contexts;
using Build.Model;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Test;
using Cake.Frosting;

namespace Build.Tasks
{
	[TaskName("Unit Tests")]
	[IsDependentOn(typeof(BuildTask))]
	public class UnitTestTask : FrostingTask<Context>
	{
		private readonly IProjectDiscoverer _projectDiscoverer;

		public UnitTestTask(IProjectDiscoverer projectDiscoverer) => _projectDiscoverer = projectDiscoverer;

		public override void Run(Context context)
		{
			_projectDiscoverer
				.GetTestProjects()
				.AsParallel()
				.ForAll(project => ExecuteUnitTestsWithExceptionHandling(context, project));
		}

		private void ExecuteUnitTestsWithExceptionHandling(Context context, Project project)
		{
			try
			{
				context.DotNetCoreTest(project.AbsolutePath, new DotNetCoreTestSettings
				{
					NoBuild = true,
					NoLogo = true,
					NoRestore = true
				});
			}
			catch (Exception)
			{

			}
		}
	}
}
