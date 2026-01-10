## Learning .NET

Repository with .NET 9.0 demo applications to learn and explore various algorithms and utilities. The project follows .NET best practices with a clean separation between Core business logic and ConsoleApp UI.

## Quick Start

### Install .NET on macOS

This requires the package manager _brew_:

```bash
brew install dotnet
```

### Build and Run

```bash
# Build the entire solution
dotnet build

# Run the interactive menu
dotnet run --project src/LearningDotNet.ConsoleApp
```

## Available Demos

The application provides 5 different demos. You can either:
- Run interactively and choose from the menu
- Pass the demo number as a command-line argument
- Pass additional arguments for specific demos

### 1. Binary Multiplier

Interactive calculator for binary number arithmetic operations.

**Run:**
```bash
dotnet run --project src/LearningDotNet.ConsoleApp 1
```

**Example:**
```
Enter first binary number: 101
Enter second binary number: 11
Result: 101 * 11 = 1111 (5 * 3 = 15)
```

### 2. German Number to Word Converter

Converts numeric values to their German word representation.

**Run:**
```bash
# Interactive mode
dotnet run --project src/LearningDotNet.ConsoleApp 2

# With argument
dotnet run --project src/LearningDotNet.ConsoleApp 2 12345
```

**Example:**
```
12345 -> zwölftausenddreihundertfünfundvierzig
23 -> dreiundzwanzig
```

### 3. Pascal Triangle Generator

Generates and displays Pascal's Triangle to a specified depth.

**Run:**
```bash
# Interactive mode (default depth: 5)
dotnet run --project src/LearningDotNet.ConsoleApp 3

# With custom depth
dotnet run --project src/LearningDotNet.ConsoleApp 3 8
```

**Example output (depth 5):**
```
       1
      1 1
     1 2 1
    1 3 3 1
   1 4 6 4 1
```

### 4. Binary String Demo

Demonstrates binary string manipulation and operations.

**Run:**
```bash
dotnet run --project src/LearningDotNet.ConsoleApp 4
```

**Example:**
```
Binary operations and string manipulations demo
```

### 5. German Word to Number Parser

Parses German number words and converts them to numeric values. Supports both integer and decimal numbers.

**Run:**
```bash
# Interactive mode
dotnet run --project src/LearningDotNet.ConsoleApp 5

# With German word argument
dotnet run --project src/LearningDotNet.ConsoleApp 5 dreiundzwanzig
dotnet run --project src/LearningDotNet.ConsoleApp 5 zehnmillionenfünfhunderttausenddreiundzwanzig
dotnet run --project src/LearningDotNet.ConsoleApp 5 dreiundzwanzigkommavierfünfdrei
```

**Examples:**
```
dreiundzwanzig -> 23
einhundertzwölf -> 112
zehnmillionenfünfhunderttausenddreiundzwanzig -> 10500023
dreiundzwanzigkommavierfünfdrei -> 23.453
dreikommaeinsvier -> 3.14
eintausendkommazweifünf -> 1000.25
```

## Running Tests

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity detailed

# Run specific test class
dotnet test --filter "GermanNumberParserTests"
```

## Project Structure

```
learning-dot-net/
├── src/
│   ├── LearningDotNet.Core/              # Core business logic library
│   │   ├── Mathematics/                  # Math operations
│   │   ├── Converters/                   # Number converters
│   │   └── Common/                       # Shared utilities
│   └── LearningDotNet.ConsoleApp/        # Console UI application
│       ├── Menus/                        # Menu system
│       └── Demos/                        # Demo implementations
├── tests/
│   └── LearningDotNet.Core.Tests/        # Unit tests
└── LearningDotNet.sln                    # Solution file
```

## Features

- ✅ Clean architecture with separation of concerns
- ✅ Comprehensive unit test coverage (145/146 tests passing)
- ✅ Command-line argument support for automated testing
- ✅ Interactive menu for easy exploration
- ✅ .NET 9.0 with modern C# features
