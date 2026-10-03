using puzzle_bomb_generator;

List<Wire> wires = new List<Wire>();
Random rand = new Random();
for (int i = 0; i < 5; i++)
{
    Wire wire = Wire.GenerateRandomWire(rand, i, i);
    Console.WriteLine(wire);
    wires.Add(wire);
}
