using Build.Handlers;
using Cake.Common.Tools.DotNetCore;
using Cake.Frosting;
using System;
using System.Linq;

namespace Build.Tasks
{
	[TaskName("Clean Build Outputs")]
	public class CleanTask : FrostingTask<BuildContext>
	{
		private readonly IProjectFileHandler _projectFileHandler;

		public CleanTask(IProjectFileHandler projectFileHandler)
		{
			_projectFileHandler = projectFileHandler;
		}

		public override void Run(BuildContext context)
		{
			_projectFileHandler
				.GetAllProjectFilePaths()
				.AsParallel()
				.ForAll(csprojPath => CleanProjectOutputWithExceptionHandling(context, csprojPath));
		}

		private void CleanProjectOutputWithExceptionHandling(BuildContext context, string csprojPath)
		{
			try
			{
				context.DotNetCoreClean(csprojPath);
			}
			catch (Exception ex)
			{
				
			}
		}
	}
}
