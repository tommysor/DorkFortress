namespace DorkFortress;

public readonly record struct Coord
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Coord(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}