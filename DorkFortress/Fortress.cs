namespace DorkFortress;

public sealed class Fortress
{
    private readonly Dictionary<Coord, Cell> _cells = [];

    public Fortress(uint northSouthSize, uint westEastSize)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan<uint>(northSouthSize, 1, nameof(northSouthSize));
        ArgumentOutOfRangeException.ThrowIfLessThan<uint>(westEastSize, 1, nameof(westEastSize));

        MaxNorthSouth = (int)northSouthSize / 2;
        var northSouthSizeIsOdd = (northSouthSize & 1) == 1;
        MinNorthSouth = -MaxNorthSouth - (northSouthSizeIsOdd ? 1 : 0);

        MaxWestEast = (int)westEastSize / 2;
        var westEastSizeIsOdd = (westEastSize & 1) == 1;
        MinWestEast = -MaxWestEast - (westEastSizeIsOdd ? 1 : 0);

        Initialize();
    }

    internal int MaxNorthSouth { get; }
    internal int MinNorthSouth { get; }
    internal int MaxWestEast { get; }
    internal int MinWestEast { get; }

    private void Initialize()
    {
        // Create a bunch of ground cells
        for (var z = -5; z < 2; z++)
        {
            for (var x = MinWestEast; x < MaxWestEast; x++)
            {
                for (var y = MinNorthSouth; y < MaxNorthSouth; y++)
                {           
                    var coord = new Coord(x, y, z);
                    _cells.TryGetValue(new Coord(x, y, z - 1), out var cellBelow);
                    _cells.Add(coord, Cell.CreateDefaultGround(coord, cellBelow));
                }
            }
        }
        // Create a top layer of air cells
        for (var x = MinWestEast; x < MaxWestEast; x++)
        {
            for (var y = MinNorthSouth; y < MaxNorthSouth; y++)
            {           
                var coord = new Coord(x, y, 2);
                _cells.TryGetValue(new Coord(x, y, 1), out var cellBelow);
                _cells.Add(coord, Cell.CreateDefaultAir(coord, cellBelow));
            }
        }
    }
}
