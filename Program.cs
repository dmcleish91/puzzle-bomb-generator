using puzzle_bomb_generator;

int seed = 42;
Console.WriteLine($"Seed is {seed}");

PuzzleManager puzzleManager = new(seed);
puzzleManager.GeneratePuzzle(DifficultyLevel.Hard);

foreach (var wire in puzzleManager.Wires)
{
    Console.WriteLine(wire);
}