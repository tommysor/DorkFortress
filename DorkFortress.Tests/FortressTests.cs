namespace DorkFortress.Tests;

public sealed class FortressTests
{
    [Fact]
    public void ShouldValidateSize_NorthSouth()
    {
        Assert.Throws<ArgumentOutOfRangeException>("northSouthSize", () => new Fortress(0, 1));
    }

    [Fact]
    public void ShouldValidateSize_WestEast()
    {
        Assert.Throws<ArgumentOutOfRangeException>("westEastSize", () => new Fortress(1, 0));
    }

    [Theory]
    [InlineData(1, -1, 0)]
    [InlineData(2, -1, 1)]
    [InlineData(3, -2, 1)]
    public void ShouldHaveNorthSouthMinAndMax(int size, int expectedMin, int expectedMax)
    {
        var fortress = new Fortress((uint)size, 1);
        Assert.Equal(expectedMin, fortress.MinNorthSouth);
        Assert.Equal(expectedMax, fortress.MaxNorthSouth);
    }

    [Theory]
    [InlineData(1, -1, 0)]
    [InlineData(2, -1, 1)]
    [InlineData(3, -2, 1)]
    public void ShouldHaveWestEastMinAndMax(int size, int expectedMin, int expectedMax)
    {
        var fortress = new Fortress(1, (uint)size);
        Assert.Equal(expectedMin, fortress.MinWestEast);
        Assert.Equal(expectedMax, fortress.MaxWestEast);
    }
}