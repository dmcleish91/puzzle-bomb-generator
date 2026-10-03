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

    public static Wire GenerateRandomWire(Random random, int startPosition, int endPosition)
    {
        WireColor[] colors = Enum.GetValues<WireColor>();
        WireStyle[] styles = Enum.GetValues<WireStyle>();

        WireColor color = colors[random.Next(colors.Length)];
        WireStyle style = styles[random.Next(styles.Length)];
        return new Wire(startPosition, endPosition, color, style);
    }

    public override string ToString()
    {
        return $"Wire {StartPosition + 1}: Start={StartPosition}, End={EndPosition}, Color={Color}, Style={Style}";
    }

}
