using MinCodeGPT.Interfaces;
using System.Text;

namespace MinCodeGPT.Processing
{
    /// <summary>
    /// Provides functionality to minify file content based on the file extension.
    /// </summary>
    public class FileMinifier : IFileMinifier
    {
        /// <summary>
        /// Minifies the content of a file based on its extension.
        /// </summary>
        /// <param name="content">The content of the file to be minified.</param>
        /// <param name="fileExtension">The extension of the file.</param>
        /// <returns>The minified content of the file.</returns>
        public string MinifyContent(string content, string fileExtension)
        {
            var lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var sb = new StringBuilder();
            bool inBlockComment = false;
            bool inSummary = false;

            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine))
                    continue;

                switch (fileExtension)
                {
                    case ".cs":
                    case ".cshtml":
                        if (ProcessCSharpLine(trimmedLine, ref inBlockComment, ref inSummary, out string processedLine))
                        {
                            sb.Append(processedLine);
                        }
                        break;

                    case ".json":
                    case ".config":
                        if (!string.IsNullOrWhiteSpace(trimmedLine))
                        {
                            sb.Append(trimmedLine.Replace(" ", ""));
                        }
                        break;

                    case ".html":
                    case ".htm":
                        if (!trimmedLine.Contains("<!--") && !trimmedLine.Contains("-->"))
                        {
                            sb.Append(trimmedLine);
                        }
                        break;

                    default:
                        sb.AppendLine(trimmedLine);
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Processes a line of C# code to determine if it should be included in the minified content.
        /// </summary>
        /// <param name="line">The line of code to process.</param>
        /// <param name="inBlockComment">Indicates if the current line is within a block comment.</param>
        /// <param name="inSummary">Indicates if the current line is within a summary comment.</param>
        /// <param name="processedLine">The processed line to be included in the minified content.</param>
        /// <returns>True if the line should be included in the minified content; otherwise, false.</returns>
        private bool ProcessCSharpLine(string line, ref bool inBlockComment, ref bool inSummary, out string processedLine)
        {
            processedLine = string.Empty;

            if (line.StartsWith("/*") && line.EndsWith("*/"))
                return false;
            if (line.StartsWith("/*"))
            {
                inBlockComment = true;
                return false;
            }
            if (inBlockComment)
            {
                if (line.EndsWith("*/"))
                    inBlockComment = false;
                return false;
            }

            if (line.Contains("<summary>"))
            {
                inSummary = true;
                return false;
            }
            if (inSummary)
            {
                if (line.Contains("</summary>"))
                    inSummary = false;
                return false;
            }

            if (line.StartsWith("//") || line.StartsWith("///"))
                return false;

            processedLine = line.Trim();
            return true;
        }
    }
}