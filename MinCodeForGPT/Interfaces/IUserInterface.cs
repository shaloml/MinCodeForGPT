using MinCodeGPT.Models;

namespace MinCodeGPT.Interfaces
{
    /// <summary>
    /// Provides a console-based user interface for the file minifier application.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        void DisplayMenu();

        /// <summary>
        /// Gets the user's menu choice.
        /// </summary>
        /// <returns>The selected menu option as an integer.</returns>
        int GetMenuChoice();

        /// <summary>
        /// Prompts the user to enter the source directory path.
        /// </summary>
        /// <returns>The source directory path as a string.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown when the specified directory does not exist.</exception>
        string GetSourceDirectory();

        /// <summary>
        /// Prompts the user to enter the output file path.
        /// </summary>
        /// <param name="sourceDir">The source directory path.</param>
        /// <returns>The output file path as a string.</returns>
        string GetOutputPath(string sourceDir);

        /// <summary>
        /// Asks the user if they want to continue and minify another directory.
        /// </summary>
        /// <returns>True if the user wants to continue; otherwise, false.</returns>
        bool ShouldContinue();

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        void ShowError(string message);

        /// <summary>
        /// Displays a progress message to the user.
        /// </summary>
        /// <param name="message">The progress message to display.</param>
        void ShowProgress(string message);

        /// <summary>
        /// Displays a summary of the processing results to the user.
        /// </summary>
        /// <param name="summary">The processing summary containing the results.</param>
        void ShowSummary(ProcessingSummary summary);
    }
}
