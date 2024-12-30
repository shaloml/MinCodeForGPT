// Program.cs
namespace MinCodeGPT.Options
{
    /// <summary>
    /// Represents the processing options for the application.
    /// </summary>
    public class ProcessingOptions
    {
        /// <summary>
        /// Gets or sets the choice for file patterns.
        /// </summary>
        public int Choice { get; set; }

        /// <summary>
        /// Gets or sets the source directory for processing files.
        /// </summary>
        public string SourceDirectory { get; set; }

        /// <summary>
        /// Gets or sets the output path for processed files.
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// Gets the file patterns based on the choice.
        /// </summary>
        /// <returns>An array of file patterns.</returns>
        /// <exception cref="ArgumentException">Thrown when the choice is invalid.</exception>
        public string[] GetFilePatterns()
        {
            return Choice switch
            {
                1 => new[] { "*.cs", "*.csproj" },
                2 => new[] { "*.cs", "*.csproj", "*.json", "web.config", "*.config" },
                3 => new[] { "*.cs", "*.csproj", "*.json", "web.config", "*.config", "*.cshtml", "*.html", "*.htm" },
                _ => throw new ArgumentException("Invalid choice")
            };
        }
    }
}
