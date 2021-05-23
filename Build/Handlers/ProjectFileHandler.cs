using System.Collections.Generic;
using System.IO;
using System.Linq;
using Path = System.IO.Path;

namespace Build.Handlers
{
	internal class ProjectFileHandler : IProjectFileHandler
	{
		private readonly List<string> _projectFilePaths;

		public ProjectFileHandler()
		{
			_projectFilePaths = Directory
				.EnumerateFiles(Path.Combine(Directory.GetCurrentDirectory(), "..", "Src"), "*.csproj", SearchOption.AllDirectories)
				.ToList();
		}

		public IEnumerable<string> GetAllProjectFilePaths() => _projectFilePaths;

		public IEnumerable<string> GetNonTestProjectFilePaths() => _projectFilePaths.Where(p => !p.EndsWith("Tests.csproj"));

		public IEnumerable<string> GetTestProjectFilePaths() => _projectFilePaths.Where(p => p.EndsWith(".Tests.csproj"));

		public IEnumerable<string> GetIntegrationTestProjectFilePaths() => _projectFilePaths.Where(p => p.EndsWith(".IntegrationTests.csproj"));
	}
}
