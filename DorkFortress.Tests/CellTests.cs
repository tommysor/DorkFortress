namespace DorkFortress.Tests;

public class CellTests
{
    [Fact]
    public void CreateCell_ShouldHaveCoordinate()
    {
        var actual = Cell.CreateCell(new Coord(1, 2, 3));
        Assert.Equal(new Coord(1, 2, 3), actual.Coord);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateCell_ShouldHaveFloor(bool expectedHasFloor)
    {
        var actual = Cell.CreateCell(new Coord(1, 2, 3), expectedHasFloor);
        Assert.Equal(expectedHasFloor, actual.HasFloor);
    }
}