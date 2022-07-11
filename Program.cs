using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add some dummy data to the database
ItemContext db = new ItemContext("temp-webapi");
db.Add(new Item {Name = "Tralala 1", Value = "Some value"});
db.Add(new Item {Name = "Yet another item", Value = "Some more value here"});
db.SaveChanges();

// ==================
// Endpoints

// Basic one-liner examples
app.MapGet( "/", () => "Basic API with database example" );
app.MapGet( "/time", () => DateTime.UtcNow );

// List all items in database
app.MapGet("/items", () =>
    db.Items
    .OrderBy(i => i.Id)
);

app.MapPost("/new", async (Item i) =>
{
    db.Add(i);
    await db.SaveChangesAsync();
    return Results.Created($"/new/{i.Id}", i);
});

// How to Modify / Delete item number 2 using GET method example
/*
app.MapGet("/delete2", () =>
{
    // querry the item using Where method
    var item = db.Items.Where(i => i.Id == 2).First();
    db.Remove(item);
    db.SaveChanges();
});
*/

// ==================

app.UseHttpsRedirection();
app.Run();
