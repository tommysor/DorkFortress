namespace DorkFortress;

public sealed class Cell
{
    public Coord Coord { get; }
    private readonly Cell? _cellBelow;
    private Material _material;

    private Cell(Coord coord, Cell? cellBelow)
    {
        if (cellBelow is not null)
        {
            var expectedCoord = new Coord(coord.X, coord.Y, coord.Z - 1);
            if (cellBelow.Coord != expectedCoord)
            {
                throw new ArgumentException($"Expected coordinate directly below: {expectedCoord}, but got {cellBelow.Coord}", nameof(cellBelow));
            }
        }
        Coord = coord;
        _cellBelow = cellBelow;
    }

    internal static Cell CreateDefaultGround(Coord coord, Cell? cellBelow)
    {
        var cell = new Cell(coord, cellBelow)
        {
            _material = Material.Dirt,
        };
        return cell;
    }

    internal static Cell CreateDefaultAir(Coord coord, Cell? cellBelow)
    {
        var cell = new Cell(coord, cellBelow)
        {
            _material = Material.Air,
        };
        return cell;
    }

    public bool HasFloor => _material == Material.Air && _cellBelow?._material.IsSolid() == true;
}