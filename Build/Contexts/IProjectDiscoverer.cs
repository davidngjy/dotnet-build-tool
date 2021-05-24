using System.Collections.Generic;
using Build.Model;

namespace Build.Contexts
{
	public interface IProjectDiscoverer
	{
		IEnumerable<Project> GetAllProjects();
		IEnumerable<Project> GetNonTestProjects();
		IEnumerable<Project> GetTestProjects();
		IEnumerable<Project> GetIntegrationTestProjects();
	}
}