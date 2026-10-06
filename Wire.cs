namespace puzzle_bomb_generator;

public enum WireStyle
{
    Curly,
    Thick,
    Thin
}

public enum WireColor
{
    Red,
    Blue,
    Green,
    Yellow,
    Orange,
    Black,
    White
}
internal class Wire(int startPosition, int endPosition, WireColor color, WireStyle style)
{
    public int StartPosition { get; } = startPosition;
    public int EndPosition { get; set; } = endPosition;
    public WireColor Color { get; } = color;
    public WireStyle Style { get; } = style;
    public List<int> CrossedWires { get; } = [];

    public override string ToString()
    {
        string crosses = CrossedWires.Count == 0
            ? "none"
            : string.Join(", ", CrossedWires.Select(position => $"Wire {position + 1}"));

        return $"Wire {StartPosition + 1}: Start={StartPosition}, End={EndPosition}, Color={Color}, Style={Style}, Crosses={crosses}";
    }

}
