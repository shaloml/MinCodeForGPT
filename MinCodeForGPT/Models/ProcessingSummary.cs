namespace MinCodeGPT.Models
{
    /// <summary>
    /// Represents a summary of the processing results.
    /// </summary>
    public class ProcessingSummary
    {
        /// <summary>
        /// Gets or sets the total number of files processed.
        /// </summary>
        public int TotalFiles { get; set; }

        /// <summary>
        /// Gets or sets the statistics of file types processed.
        /// </summary>
        public Dictionary<string, int> FileTypeStats { get; set; } = new();

        /// <summary>
        /// Gets or sets the output path where the results are stored.
        /// </summary>
        public string OutputPath { get; set; }
    }
}
