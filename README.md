# File Minifier

A powerful .NET console application for minifying and consolidating multiple source code files into a single text file. Designed specifically for preparing code for AI model interactions (like ChatGPT/Claude) by removing comments and unnecessary whitespace while preserving code functionality.

## 🌟 Features

- Multiple minification modes:
  - C# files only (including .csproj)
  - C# + JSON (including .csproj, web.config, and appsettings)
  - Full web project (C#, JSON, HTML, and related files)
- Smart default output path generation with GUID for uniqueness
- Detailed processing logs
- File type statistics
- Preserves file structure with clear file separation
- Handles multiple file types appropriately:
  - Removes C# comments (single-line, multi-line, and XML documentation)
  - Minifies JSON and config files
  - Strips HTML comments while preserving structure
  - Maintains code readability

## 📋 Requirements

- .NET 6.0 or higher
- Windows/Linux/macOS compatible

## 🚀 Quick Start

1. Clone the repository:
```bash
git clone https://github.com/yourusername/file-minifier.git
```

2. Build the project:
```bash
cd file-minifier
dotnet build
```

3. Run the application:
```bash
dotnet run
```

## 💻 Usage

1. Launch the application
2. Select processing mode (1-3 or Enter for default):
   - Option 1 (Default): C# files only
   - Option 2: C# + JSON files
   - Option 3: All web project files
3. Enter source directory path
4. Optionally specify output file path (or press Enter for default)
5. Review processing logs and statistics

Default output path format:
```
c:\temp\gptmin\[SourceFolderName]_[Guid].txt
```

## 📝 File Type Support

### Mode 1 (Default)
- `.cs` - C# source files
- `.csproj` - Project files

### Mode 2
- All from Mode 1
- `.json` - JSON files
- `.config` - Configuration files
- `web.config` - Web configuration files

### Mode 3
- All from Mode 2
- `.cshtml` - Razor views
- `.html` - HTML files
- `.htm` - HTML files

## 📊 Output Format

The output file contains:
- Clear file separators
- Full file paths as comments
- Minified content
- Processing statistics

Example output:
```
// File: C:\Projects\MyProject\Program.cs
namespace MyProject{class Program{static void Main(string[]args){...}}}

---

// File: C:\Projects\MyProject\appsettings.json
{"Logging":{"LogLevel":{"Default":"Information"}}}

---
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔍 Troubleshooting

- Ensure source directory exists and is accessible
- Check write permissions for output directory
- For large projects, ensure adequate system memory
