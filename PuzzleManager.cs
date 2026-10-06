namespace puzzle_bomb_generator;

internal class PuzzleManager(int seed)
{
    private readonly Random _random = new(seed);
    private const double ChanceToCross = 0.35;
    public List<Wire> Wires { get; } = [];

    public void GeneratePuzzle(DifficultyLevel level)
    {
        (int wireCount, int paletteSize) = GetDifficultySettings(level);
        Wires.Clear();
        WireColor[] colors = PickColors(wireCount, paletteSize);
        WireStyle[] styles = Enum.GetValues<WireStyle>();
        for (int i = 0; i < wireCount; i++)
        {
            WireColor color = colors[i];
            WireStyle style = styles[_random.Next(styles.Length)];
            Wire newWire = new(i, i, color, style);
            Wires.Add(newWire);
        }
        CrossWires();
    }

    private WireColor[] PickColors(int wireCount, int paletteSize)
    {
        WireColor[] allColors = Enum.GetValues<WireColor>();
        Shuffle(allColors);
        WireColor[] palette = [.. allColors.Take(paletteSize)];

        List<WireColor> bag = [];
        foreach (var color in palette)
        {
            bag.Add(color);
            bag.Add(color);
        }
        Shuffle(bag);
        return [.. bag.Take(wireCount)];
    }

    private void Shuffle<T>(IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    private void CrossWires()
    {
        int i = 0;
        while (i < Wires.Count - 1)
        {
            Wire upperWire = Wires[i];
            Wire lowerWire = Wires[i + 1];
            if (_random.NextDouble() < ChanceToCross)
            {
                (upperWire.EndPosition, lowerWire.EndPosition) = (lowerWire.EndPosition, upperWire.EndPosition);
                upperWire.CrossedWires.Add(lowerWire.StartPosition);
                lowerWire.CrossedWires.Add(upperWire.StartPosition);
                i += 2;
            } 
            else
            {
                i++;
            }
        }
    }

    private static (int wireCount, int paletteSize) GetDifficultySettings(DifficultyLevel level)
    {
        return level switch
        {
            DifficultyLevel.Easy => (3, 3),
            DifficultyLevel.Medium => (4, 4),
            DifficultyLevel.Hard => (7, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(level), $"Not expected difficulty level value: {level}"),
        };
    }
}