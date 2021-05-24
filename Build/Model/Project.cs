using System.Text.RegularExpressions;

namespace Build.Model
{
	public class Project
	{
		private static readonly Regex ProjectNameRegex = new Regex("([\\w.]*).csproj$", RegexOptions.Compiled);
		private readonly string _absolutePath;

		public string ProjectName => ProjectNameRegex.Match(_absolutePath).Groups[1].Value;
		public string AbsolutePath => _absolutePath;

		public Project(string absolutePath) => _absolutePath = absolutePath;
	}
}
