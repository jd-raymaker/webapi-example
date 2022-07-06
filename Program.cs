WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

// ==================
// Endpoints

app.MapGet( "/hello", () => "Hello World" );
app.MapGet( "/time", () => DateTime.UtcNow );

// ==================

app.UseHttpsRedirection();
app.Run();
