namespace DorkFortress.Tests;

public class DorkTests
{
    [Fact]
    public void ShouldHaveCoordinate()
    {
        var actual = new Dork(new Coord(1, 2, 3), "John");
        Assert.Equal(new Coord(1, 2, 3), actual.Coord);
    }

    [Fact]
    public void ShouldHaveName()
    {
        var actual = new Dork(new Coord(1, 2, 3), "John");
        Assert.Equal("John", actual.Name);
    }

    [Fact]
    public void ShouldRequireName()
    {
        Assert.Throws<ArgumentNullException>("name", () => new Dork(new Coord(1, 2, 3), null!));
        Assert.Throws<ArgumentException>("name", () => new Dork(new Coord(1, 2, 3), ""));
        Assert.Throws<ArgumentException>("name", () => new Dork(new Coord(1, 2, 3), " "));
    }

    [Fact]
    public void ShouldHaveUniqueId()
    {
        var dork1 = new Dork(new Coord(1, 2, 3), "John");
        var dork2 = new Dork(new Coord(1, 2, 3), "John");
        Assert.NotEqual(dork1.Id, dork2.Id);
    }
}