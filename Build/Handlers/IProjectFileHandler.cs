using System.Collections.Generic;

namespace Build.Handlers
{
	public interface IProjectFileHandler
	{
		IEnumerable<string> GetAllProjectFilePaths();
		IEnumerable<string> GetNonTestProjectFilePaths();
		IEnumerable<string> GetTestProjectFilePaths();
		IEnumerable<string> GetIntegrationTestProjectFilePaths();
	}
}