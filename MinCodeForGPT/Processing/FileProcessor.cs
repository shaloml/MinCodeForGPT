using MinCodeGPT.Interfaces;
using MinCodeGPT.Models;
using MinCodeGPT.Options;
using System.Text;

namespace MinCodeGPT.Processing
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IUserInterface _ui;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcessor"/> class.
        /// </summary>
        /// <param name="ui">The user interface instance to interact with the user.</param>
        /// <exception cref="ArgumentNullException">Thrown when the ui parameter is null.</exception>
        public FileProcessor(IUserInterface ui)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
        }

        /// <summary>
        /// Processes the files based on the provided options and minifier.
        /// </summary>
        /// <param name="options">The processing options containing source directory, output path, and file patterns.</param>
        /// <param name="minifier">The file minifier to minify the content of the files.</param>
        public void ProcessFiles(ProcessingOptions options, IFileMinifier minifier)
        {
            var filePatterns = options.GetFilePatterns();
            var files = new List<string>();

            foreach (var pattern in filePatterns)
            {
                files.AddRange(Directory.GetFiles(options.SourceDirectory, pattern, SearchOption.AllDirectories));
            }

            _ui.ShowProgress($"\nFound {files.Count} files to process...");

            var summary = new ProcessingSummary
            {
                OutputPath = options.OutputPath
            };

            var sb = new StringBuilder();

            foreach (var file in files)
            {
                try
                {
                    ProcessFile(file, minifier, sb, summary);
                }
                catch (Exception ex)
                {
                    _ui.ShowError($"Error processing {file}: {ex.Message}");
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(options.OutputPath)!);
            File.WriteAllText(options.OutputPath, sb.ToString());

            _ui.ShowSummary(summary);
        }

        /// <summary>
        /// Processes a single file, minifies its content, and updates the summary.
        /// </summary>
        /// <param name="file">The file to process.</param>
        /// <param name="minifier">The file minifier to minify the content of the file.</param>
        /// <param name="sb">The StringBuilder to accumulate the minified content.</param>
        /// <param name="summary">The summary object to update the processing statistics.</param>
        private void ProcessFile(string file, IFileMinifier minifier, StringBuilder sb, ProcessingSummary summary)
        {
            string extension = Path.GetExtension(file).ToLower();

            if (!summary.FileTypeStats.ContainsKey(extension))
                summary.FileTypeStats[extension] = 0;
            summary.FileTypeStats[extension]++;

            _ui.ShowProgress($"Processing: {file}");

            var fileContent = File.ReadAllText(file);
            var minifiedContent = minifier.MinifyContent(fileContent, extension);

            sb.AppendLine($"// File: {file}");
            sb.AppendLine(minifiedContent);
            sb.AppendLine("\n---\n");

            summary.TotalFiles++;
            _ui.ShowProgress($"Progress: {summary.TotalFiles}/{summary.FileTypeStats.Values.Sum()} files processed");
        }
    }
}
