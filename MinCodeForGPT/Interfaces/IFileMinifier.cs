namespace MinCodeGPT.Interfaces
{
    /// <summary>
    /// Provides functionality to minify file content based on the file extension.
    /// </summary>
    public interface IFileMinifier
    {
        /// <summary>
        /// Minifies the content of a file based on its extension.
        /// </summary>
        /// <param name="content">The content of the file to be minified.</param>
        /// <param name="fileExtension">The extension of the file.</param>
        /// <returns>The minified content of the file.</returns>
        string MinifyContent(string content, string fileExtension);
    }
}
