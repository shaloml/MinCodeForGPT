# File Minifier

A powerful cross-platform console application for minifying and consolidating multiple source code files into a single text file. Designed specifically for preparing code for AI model interactions (like ChatGPT/Claude) by removing comments and unnecessary whitespace while preserving code functionality.

## 🌟 Features

- Multiple minification modes:
  - C# files only (including .csproj)
  - C# + JSON (including .csproj, web.config, and appsettings)
  - Full web project (C#, JSON, HTML, and related files)
- Smart default output path generation with GUID for uniqueness
- Detailed processing logs and statistics
- Cross-platform support (Windows, Linux, macOS)
- Self-contained single executable
- File type statistics and summaries
- Preserves file structure with clear file separation

## 📋 Requirements

For Building:
- .NET 8.0 SDK
- PowerShell (Windows) or Bash (Linux/macOS) for build scripts

For Running:
- No requirements - executables are self-contained

## 🚀 Quick Start

### Building from Source

1. Clone the repository:
```bash
git clone https://github.com/yourusername/file-minifier.git
cd file-minifier
```

2. Build for all platforms:

Windows:
```powershell
.\build.ps1
```

Linux/macOS:
```bash
chmod +x build.sh
./build.sh
```

### Running the Application

Windows:
```bash
.\FileMinifier.exe
```

Linux/macOS:
```bash
chmod +x FileMinifier
./FileMinifier
```

## 💻 Usage

1. Launch the application
2. Select processing mode (1-3 or Enter for default):
   - Option 1 (Default): C# files only
   - Option 2: C# + JSON files (including web.config)
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
- `.html/.htm` - HTML files

## 🔧 Build Artifacts

After building, you'll find the executables in the `publish` directory:

```
publish/
├── win-x64/
│   └── FileMinifier.exe    # Windows executable
├── linux-x64/
│   └── FileMinifier        # Linux executable
├── osx-x64/
│   └── FileMinifier        # macOS Intel executable
└── osx-arm64/
    └── FileMinifier        # macOS Apple Silicon executable
```

## 📊 Output Format

The output file contains:
```
// File: C:\Projects\MyProject\Program.cs
namespace MyProject{class Program{static void Main(string[]args){...}}}

---

// File: C:\Projects\MyProject\appsettings.json
{"Logging":{"LogLevel":{"Default":"Information"}}}

---
```

## 🔍 Troubleshooting

Common issues and solutions:

### Windows
- If you get "Access Denied" errors, try running as administrator
- Ensure antivirus is not blocking the executable

### Linux/macOS
- If you can't execute the file, set permissions:
  ```bash
  chmod +x FileMinifier
  ```
- For macOS security warning, go to System Preferences > Security & Privacy

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


## 🙏 Acknowledgments

- Thanks to all contributors
- Inspired by the need for efficient code sharing with AI models