// Initialize new instance of WebAppBuilder
var builder = WebApplication.CreateBuilder(args);
// Build WebApp
var app = builder.Build();

ItemContext db = new ItemContext("temp-webapi");

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

// Receive POST request and store it to the database.
// Accepts RAW packet with JSON
app.MapPost("/new", async (Item i) =>
{
    db.Add(i);
    await db.SaveChangesAsync();
    return Results.Created($"/new/{i.Id}", i);
});

// ==================

app.UseHttpsRedirection();
app.Run();
