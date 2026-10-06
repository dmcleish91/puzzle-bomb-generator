# Puzzle Bomb Generator

A C# console app that generates wire-cutting bomb puzzles and the hints needed to solve them.

## Description

An easy-to-follow example of procedural puzzle generation. Each puzzle is a row of wires. Every wire has a color, a style (curly, thick or thin), and may cross the wire next to it. One wire is the correct wire to cut, and the generator builds a short list of true hints that narrows the board down to exactly that wire.

## Getting Started

### Dependencies

* [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Executing program

Run the app from the project folder:

```
dotnet run
```

The app prints the seed followed by one line per wire, showing its start and end positions, color, style and which wire it crosses.

The same seed always produces the same board. To get a different puzzle, change the `seed` value in `Program.cs`. To change the number of wires and colors, pass `DifficultyLevel.Easy`, `DifficultyLevel.Medium` or `DifficultyLevel.Hard` to `GeneratePuzzle`.
