namespace DorkFortress.Tests;

public class CellTests
{
    [Fact]
    public void CellBelow_ShouldBeOneZLevelLower()
    {
        var wrongBelow = Cell.CreateDefaultGround(new Coord(0, 1, 0), null);
        Assert.Throws<ArgumentException>("cellBelow", () => Cell.CreateDefaultAir(new Coord(0, 0, 1), wrongBelow));

        var correctBelow = Cell.CreateDefaultGround(new Coord(0, 0, 0), null);
        var actual2 = Cell.CreateDefaultAir(new Coord(0, 0, 1), correctBelow);
        Assert.NotNull(actual2);
    }

    [Fact]
    public void HasFloor_ShouldBeTrue_WhenOpenSpaceAboveSolidGround()
    {
        var ground = Cell.CreateDefaultGround(new Coord(0, 0, 0), null);
        var actual = Cell.CreateDefaultAir(new Coord(0, 0, 1), ground);
        Assert.True(actual.HasFloor);
    }

    [Fact]
    public void HasFloor_ShouldBeFalse_WhenOpenSpaceAboveOpenSpace()
    {
        var openSpace = Cell.CreateDefaultAir(new Coord(0, 0, 0), null);
        var actual = Cell.CreateDefaultAir(new Coord(0, 0, 1), openSpace);
        Assert.False(actual.HasFloor);
    }

    [Fact]
    public void HasFloor_ShouldBeFalse_WhenSolidGround()
    {
        var ground = Cell.CreateDefaultGround(new Coord(0, 0, 0), null);
        var actual = Cell.CreateDefaultGround(new Coord(0, 0, 1), ground);
        Assert.False(actual.HasFloor);
    }
}