using MinCodeGPT.Options;

namespace MinCodeGPT.Interfaces
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileProcessor"/> class.
    /// </summary>
    /// <param name="ui">The user interface instance to interact with the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when the ui parameter is null.</exception>
    public interface IFileProcessor
    {
        /// <summary>
        /// Processes the files based on the provided options and minifier.
        /// </summary>
        /// <param name="options">The processing options containing source directory, output path, and file patterns.</param>
        /// <param name="minifier">The file minifier to minify the content of the files.</param>
        void ProcessFiles(ProcessingOptions options, IFileMinifier minifier);
    }
}
