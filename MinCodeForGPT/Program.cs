using MinCodeGPT;

/// <summary>
/// The main entry point for the application.
/// </summary>
class Program
{
    /// <summary>
    /// The main method which initializes and runs the MinifierApplication.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        var minifierApp = new MinifierApplication();

        minifierApp.Run();
    }
}
