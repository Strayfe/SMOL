var app = WebApplication.CreateBuilder(args).Build();
app.MapGet("/", () => "Smol snek monch bred!");
app.Run();
