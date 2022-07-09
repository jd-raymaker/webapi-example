using Microsoft.EntityFrameworkCore;

public class ItemContext : DbContext
{
    public DbSet<Item>? Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("temp-webapi");
    }
}

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}
