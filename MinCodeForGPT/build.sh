#!/bin/bash

# Create publish directory if it doesn't exist
mkdir -p publish

# Build for each platform
platforms=("win-x64" "linux-x64" "osx-x64" "osx-arm64")

for platform in "${platforms[@]}"
do
    echo "Building for $platform..."
    dotnet publish -c Release -r $platform --self-contained true
done

echo -e "\nBuild completed! Executables are in the 'publish' directory:"
echo "Windows (x64): publish/win-x64/FileMinifier.exe"
echo "Linux (x64):   publish/linux-x64/FileMinifier"
echo "macOS (x64):   publish/osx-x64/FileMinifier"
echo "macOS (ARM64): publish/osx-arm64/FileMinifier"