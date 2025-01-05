namespace DorkFortress;

public sealed class Cell
{
    public Coord Coord { get; }
    public bool HasFloor { get; private set; }

    private Cell(Coord coord, bool hasFloor)
    {
        Coord = coord;
        HasFloor = hasFloor;
    }

    internal static Cell CreateCell(Coord coord, bool hasFloor = true)
    {
        var cell = new Cell(coord, hasFloor);
        return cell;
    }
}