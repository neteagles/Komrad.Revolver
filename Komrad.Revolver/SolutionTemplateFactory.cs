namespace Komrad.Revolver
{
    using System.IO;

    public class SolutionTemplateFactory
    {
        public const string SourcesPath = "sources";

        public SolutionTemplate Create(string rootPath)
        {
            var sourcesPath = Path.Combine(rootPath, SourcesPath);

            return new SolutionTemplate();
        }
    }
}