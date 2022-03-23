namespace SMOL.Repositories;

internal class SnekRepository
{
    private readonly Dictionary<int, Snek> _sneks = new()
    {
        { 1, new Snek(1, "Smol Snek") },
        { 2, new Snek(2, "Sneaky Snek") },
    };

    public void Create(Snek snek) => _sneks[snek.Id] = snek;

    public IEnumerable<Snek> GetAll() => _sneks.Values.AsEnumerable();

    public Snek? GetById(int id) => _sneks.GetValueOrDefault(id);

    public void Update(Snek snek)
    {
        var existingSnek = GetById(snek.Id);
        if (existingSnek is null)
            return;

        _sneks[snek.Id] = snek;
    }

    public void Delete(int id) => _sneks.Remove(id);
}