using MinCodeGPT.Interfaces;
using MinCodeGPT.Models;

namespace MinCodeGPT
{
    /// <summary>
    /// Provides a console-based user interface for the file minifier application.
    /// </summary>
    public class ConsoleUI : IUserInterface
    {
        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("=== File Minifier ===");
            Console.WriteLine("1. C# files only (including .csproj) [default - press Enter]");
            Console.WriteLine("2. C# and JSON files (including .csproj, web.config and appsettings)");
            Console.WriteLine("3. C# and HTML files (including all from option 2 plus .cshtml, .html)");
            Console.WriteLine("\nPlease select an option (1-3 or Enter for default):");
        }

        /// <summary>
        /// Gets the user's menu choice.
        /// </summary>
        /// <returns>The selected menu option as an integer.</returns>
        public int GetMenuChoice()
        {
            string input = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(input))
                return 1;

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                return choice;

            Console.WriteLine("Invalid choice. Using default (1).");
            return 1;
        }

        /// <summary>
        /// Prompts the user to enter the source directory path.
        /// </summary>
        /// <returns>The source directory path as a string.</returns>
        /// <exception cref="DirectoryNotFoundException">Thrown when the specified directory does not exist.</exception>
        public string GetSourceDirectory()
        {
            Console.WriteLine("\nPlease enter source directory path:");
            string sourceDir = Console.ReadLine()?.Trim() ?? "";

            if (!Directory.Exists(sourceDir))
                throw new DirectoryNotFoundException("Directory does not exist!");

            return sourceDir;
        }

        /// <summary>
        /// Prompts the user to enter the output file path.
        /// </summary>
        /// <param name="sourceDir">The source directory path.</param>
        /// <returns>The output file path as a string.</returns>
        public string GetOutputPath(string sourceDir)
        {
            string lastFolderName = new DirectoryInfo(sourceDir).Name;
            string defaultOutput = Path.Combine("c:", "temp", "gptmin", $"{lastFolderName}_{Guid.NewGuid():N}.txt");

            Console.WriteLine($"\nOutput file path (press Enter for default: {defaultOutput}):");
            string outputPath = Console.ReadLine()?.Trim() ?? "";

            return string.IsNullOrWhiteSpace(outputPath) ? defaultOutput : outputPath;
        }

        /// <summary>
        /// Asks the user if they want to continue and minify another directory.
        /// </summary>
        /// <returns>True if the user wants to continue; otherwise, false.</returns>
        public bool ShouldContinue()
        {
            Console.WriteLine("\nWould you like to minify another directory? (Y/N)");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        public void ShowError(string message)
        {
            Console.WriteLine($"\nError occurred: {message}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a progress message to the user.
        /// </summary>
        /// <param name="message">The progress message to display.</param>
        public void ShowProgress(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays a summary of the processing results to the user.
        /// </summary>
        /// <param name="summary">The processing summary containing the results.</param>
        public void ShowSummary(ProcessingSummary summary)
        {
            Console.WriteLine("\nProcessing Summary:");
            Console.WriteLine($"Total files processed: {summary.TotalFiles}");

            foreach (var stat in summary.FileTypeStats.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{stat.Key}: {stat.Value} files");
            }

            Console.WriteLine($"\nOutput saved to: {summary.OutputPath}");
        }
    }
}
