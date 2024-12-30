using MinCodeGPT.Interfaces;
using MinCodeGPT.Options;
using MinCodeGPT.Processing;

namespace MinCodeGPT
{
    /// <summary>
    /// Represents the main application class for the Minifier application.
    /// </summary>
    public class MinifierApplication
    {
        private readonly IUserInterface _ui;
        private readonly IFileProcessor _fileProcessor;
        private readonly IFileMinifier _minifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinifierApplication"/> class.
        /// </summary>
        public MinifierApplication()
        {
            _ui = new ConsoleUI();
            _fileProcessor = new FileProcessor(_ui);
            _minifier = new FileMinifier();
        }

        /// <summary>
        /// Runs the main loop of the application.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    _ui.DisplayMenu();

                    var choice = _ui.GetMenuChoice();
                    var sourceDirectory = _ui.GetSourceDirectory();
                    var outputPath = _ui.GetOutputPath(sourceDirectory);

                    var options = new ProcessingOptions
                    {
                        Choice = choice,
                        SourceDirectory = sourceDirectory,
                        OutputPath = outputPath
                    };

                    _fileProcessor.ProcessFiles(options, _minifier);

                    if (!_ui.ShouldContinue())
                        break;
                }
                catch (Exception ex)
                {
                    _ui.ShowError(ex.Message);
                }
            }
        }
    }
}
