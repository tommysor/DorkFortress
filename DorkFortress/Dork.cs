namespace DorkFortress
{
    public sealed class Dork
    {
        public Guid Id { get; }
        public Coord Coord { get; }
        public string Name { get; }

        internal Dork(Coord coord, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Id = Guid.NewGuid();
            Coord = coord;
            Name = name;
        }
    }
}