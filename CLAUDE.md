# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a learning repository for .NET 9.0 development, containing various educational programs and utilities written in C#. It serves as a practice environment for exploring different .NET concepts and algorithms.

## Architecture and Structure

### Core Components

- **MainMenu.cs**: Entry point that provides a console menu to select different demo programs
- **BinaryMultiplier.cs**: Implementation of binary arithmetic operations including multiplication and addition
- **ZuZahlenword.cs**: German number-to-word converter supporting numbers up to billions
- **Demo.cs**: Simple demo for binary string manipulation
- **Pascal.cs**: Placeholder for Pascal's triangle implementation (contains duplicate Demo class - needs fixing)

### Project Configuration

- **Target Framework**: .NET 9.0
- **Output Type**: Console Application
- **Dependencies**: Microsoft.Extensions.Logging, Microsoft.Extensions.DependencyInjection
- **Features**: ImplicitUsings and Nullable reference types enabled

## Development Commands

### Build and Run
```bash
# Build the project
dotnet build

# Run the application (interactive menu)
dotnet run

# Run specific program directly
dotnet run 1          # Binary Multiplier
dotnet run 2          # German number converter
dotnet run 2 12345    # German number converter with input
dotnet run 3          # Demo program
```

### Project Management
```bash
# Restore dependencies
dotnet restore

# Clean build artifacts
dotnet clean

# Check .NET version
dotnet --version
```

## Known Issues

- **Pascal.cs** contains a duplicate `Demo` class definition that conflicts with **Demo.cs**, preventing successful builds
- No unit tests are currently present in the project

## Development Notes

- The project uses a simple console menu system for program selection
- Each major component is self-contained with its own `Run` method
- German language features are present in the number converter (Zahlenwortkonvertierer)
- Binary arithmetic operations are implemented from scratch without using built-in conversion methods
- The solution file (ConsoleApp1.slnx) is minimal and mostly empty

## Program Usage Patterns

When running programs:
- Interactive input prompts are common across all programs
- Command-line arguments can bypass interactive prompts where supported
- Error handling includes input validation for binary numbers and German number constraints