using Microsoft.EntityFrameworkCore;

public class ItemContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Item>? Items => Set<Item>();

    public ItemContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase(_connectionString);
    }
}

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}
