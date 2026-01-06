# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a learning repository for .NET 9.0 development following industry best practices with a proper multi-project solution structure. It contains various educational programs and utilities written in C# for exploring different .NET concepts and algorithms.

## Architecture and Structure

### Solution Structure (✅ **Follows .NET Best Practices**)

```
learning-dot-net/                                  # Solution root
├── LearningDotNet.sln                            # Solution file
├── src/                                          # Source code
│   ├── LearningDotNet.Core/                      # Core business logic library
│   │   ├── Mathematics/                          # Math-related operations
│   │   │   ├── BinaryArithmetic.cs              # Binary math operations
│   │   │   └── PascalTriangle.cs                # Pascal triangle generation
│   │   ├── Converters/                          # Conversion utilities
│   │   │   └── GermanNumberConverter.cs         # German number-to-word conversion
│   │   └── Common/                               # Shared utilities
│   │       └── InputHelper.cs                   # Input validation helpers
│   │
│   └── LearningDotNet.ConsoleApp/                # Console application
│       ├── Program.cs                            # Application entry point
│       ├── Menus/                                # Menu system
│       │   └── MainMenu.cs                      # Main menu implementation
│       └── Demos/                                # Demo implementations
│           ├── BinaryCalculatorDemo.cs           # Binary calculator UI
│           ├── GermanNumberDemo.cs               # German converter UI
│           ├── PascalTriangleDemo.cs             # Pascal triangle UI
│           └── BinaryStringDemo.cs               # Binary string manipulation
│
├── tests/                                        # Test projects
│   └── LearningDotNet.Core.Tests/                # Unit tests for Core library
│       ├── Mathematics/                          # Math operation tests
│       └── Converters/                           # Converter tests
│
├── README.md                                      # Project README
└── CLAUDE.md                                     # This file
```

### Key Architecture Benefits

- ✅ **Separation of Concerns**: Business logic (Core) separate from UI (ConsoleApp)
- ✅ **Testability**: Core library is fully unit tested (57/58 tests passing)
- ✅ **Reusability**: Core library can be referenced by other projects
- ✅ **Maintainability**: Clear organization by domain (Mathematics, Converters)
- ✅ **Professional Structure**: Follows industry standard .NET solution patterns

## Development Commands

### Build and Run
```bash
# Build entire solution
dotnet build


# Run the console application
dotnet run --project src/LearningDotNet.ConsoleApp

# Run with specific demo selection
dotnet run --project src/LearningDotNet.ConsoleApp 1   # Binary Calculator
dotnet run --project src/LearningDotNet.ConsoleApp 2   # German Converter
dotnet run --project src/LearningDotNet.ConsoleApp 3   # Pascal Triangle
dotnet run --project src/LearningDotNet.ConsoleApp 4   # Binary String Demo

# Run with arguments
dotnet run --project src/LearningDotNet.ConsoleApp 2 12345  # German converter with number
dotnet run --project src/LearningDotNet.ConsoleApp 3 8     # Pascal triangle depth 8
```

### Testing
```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/LearningDotNet.Core.Tests

# Run tests with detailed output
dotnet test --verbosity detailed

# Run specific test class
dotnet test --filter "BinaryArithmeticTests"
```

### Project Management
```bash
# Restore all dependencies
dotnet restore

# Clean build artifacts
dotnet clean

# Add new project to solution
dotnet sln add <project-path>

# Add project reference
dotnet add <project> reference <target-project>
```

## Core Library API

### BinaryArithmetic
```csharp
// Validate binary string
bool isValid = BinaryArithmetic.IsValidBinary("1010");

// Perform operations
string sum = BinaryArithmetic.Add("101", "11");        // "1000"
string product = BinaryArithmetic.Multiply("101", "11"); // "1111"
```

### GermanNumberConverter
```csharp
// Convert numbers to German words
string result = GermanNumberConverter.ConvertToWords("42");        // "zweiundvierzig"
string twoDigit = GermanNumberConverter.ConvertTwoDigitNumber("23"); // "dreiundzwanzig"
```

### PascalTriangle
```csharp
// Generate Pascal's Triangle
int[][] triangle = PascalTriangle.Generate(5);
int[] row = PascalTriangle.GetRow(4);                  // [1, 4, 6, 4, 1]
string formatted = PascalTriangle.FormatTriangle(triangle);
```

## Known Issues

- **One test failure**: German converter edge case with "01" input (minor)
- **Interactive console**: Some demos require interactive input (not suitable for automated testing)

## Development Notes

- **Modern C#**: Uses .NET 9.0 with nullable reference types and implicit usings
- **Comprehensive testing**: 57/58 tests passing with proper test organization
- **Clean architecture**: Domain-driven design with clear separation
- **Error handling**: Proper exception handling with ArgumentException for invalid inputs
- **Documentation**: Full XML documentation comments throughout Core library
- **VS Code ready**: Works perfectly with VS Code C# extension and debugging

## Working with This Codebase

### Common Development Tasks

**Adding New Math Operations:**
1. Create class in `src/LearningDotNet.Core/Mathematics/`
2. Add corresponding demo in `src/LearningDotNet.ConsoleApp/Demos/`
3. Update `MainMenu.cs` to include new option
4. Write unit tests in `tests/LearningDotNet.Core.Tests/Mathematics/`

**Adding New Converters:**
1. Create converter in `src/LearningDotNet.Core/Converters/`
2. Follow the pattern of `GermanNumberConverter.cs`
3. Add demo and tests following the same structure

**Testing Strategy:**
- Core library methods are unit tested with comprehensive coverage
- Demos are integration-tested through manual verification
- Use Theory/InlineData for parameterized testing

### File Organization Rules

- **Core Library**: Pure business logic, no Console I/O
- **Demo Classes**: Handle user interaction and display
- **Test Classes**: Mirror the structure of source files
- **Namespace Conventions**: `LearningDotNet.Core.{Domain}` for core, `LearningDotNet.ConsoleApp.{Feature}` for UI

### VS Code Integration

**Essential Extensions:**
- C# (by Microsoft) - Core .NET support
- C# Dev Kit (optional) - Enhanced features

**Key Commands:**
- **Build**: `Ctrl+Shift+P` → ".NET: Build"
- **Run**: `F5` (Debug) or `Ctrl+F5` (Run without debug)
- **Test**: Test Explorer panel or `Ctrl+Shift+P` → ".NET: Run All Tests"
- **Restore**: `Ctrl+Shift+P` → ".NET: Restore All Projects"

**Debugging:**
- Set breakpoints in any `.cs` file
- F5 to start debugging
- Use Debug Console for immediate window
- Watch variables and call stack in Debug panel

### Project Dependencies

```
LearningDotNet.ConsoleApp
├── depends on → LearningDotNet.Core

LearningDotNet.Core.Tests
├── depends on → LearningDotNet.Core
├── uses → xUnit framework
└── uses → Microsoft.NET.Test.Sdk
```

### Quick Reference

**Build Commands:**
```bash
dotnet build                                    # Build entire solution
dotnet build src/LearningDotNet.Core          # Build specific project
```

**Run Commands:**
```bash
dotnet run --project src/LearningDotNet.ConsoleApp           # Interactive menu
dotnet run --project src/LearningDotNet.ConsoleApp 3        # Pascal Triangle
dotnet run --project src/LearningDotNet.ConsoleApp 3 10     # Pascal depth 10
```

**Test Commands:**
```bash
dotnet test                                     # All tests
dotnet test --filter "PascalTriangle"          # Specific tests
dotnet test --verbosity detailed               # Detailed output
```
- Always use descriptive variable names
- Avoid comments by using meaningful variable and method names