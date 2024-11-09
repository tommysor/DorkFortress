namespace DorkFortress;

public enum Material
{
    Air,
    Dirt,
}

public static class MaterialExtensions
{
    public static bool IsSolid(this Material material) => material == Material.Dirt;
}