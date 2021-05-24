using System.Collections.Generic;
using System.IO;
using System.Linq;
using Build.Model;
using Cake.Common;
using Cake.Core;
using Path = System.IO.Path;

namespace Build.Contexts
{
	internal class ProjectDiscoverer : IProjectDiscoverer
	{
		private readonly List<string> _projectFilePaths;

		public ProjectDiscoverer(ICakeContext cakeContext)
		{
			var projectsRootPath = cakeContext.HasArgument("Path") 
				? cakeContext.Argument<string>("Path")
				: Path.Combine(Directory.GetCurrentDirectory(), "..", "Src");

			_projectFilePaths = Directory
				.EnumerateFiles(projectsRootPath, "*.csproj", SearchOption.AllDirectories)
				.ToList();
		}

		public IEnumerable<Project> GetAllProjects() => _projectFilePaths
			.Select(path => new Project(path));

		public IEnumerable<Project> GetNonTestProjects() => _projectFilePaths
			.Where(p => !p.EndsWith("Tests.csproj"))
			.Select(path => new Project(path));

		public IEnumerable<Project> GetTestProjects() => _projectFilePaths
			.Where(p => p.EndsWith(".Tests.csproj"))
			.Select(path => new Project(path));

		public IEnumerable<Project> GetIntegrationTestProjects() => _projectFilePaths
			.Where(p => p.EndsWith(".IntegrationTests.csproj"))
			.Select(path => new Project(path));
	}
}
