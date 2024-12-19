# Create publish directory if it doesn't exist
$publishDir = "publish"
if (!(Test-Path $publishDir)) {
    New-Item -ItemType Directory -Path $publishDir
}

# Build for each platform
$platforms = @(
    "win-x64",
    "linux-x64",
    "osx-x64",
    "osx-arm64"
)

foreach ($platform in $platforms) {
    Write-Host "Building for $platform..."
    dotnet publish -c Release -r $platform --self-contained true
}

Write-Host "`nBuild completed! Executables are in the 'publish' directory:"
Write-Host "Windows (x64): publish\win-x64\FileMinifier.exe"
Write-Host "Linux (x64):   publish\linux-x64\FileMinifier"
Write-Host "macOS (x64):   publish\osx-x64\FileMinifier"
Write-Host "macOS (ARM64): publish\osx-arm64\FileMinifier"