using var db = new ItemContext();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add some dummy data to the database
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
