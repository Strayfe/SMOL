using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SnekRepository>();

var app = builder.Build();

app.MapPost("/sneks", ([FromServices] SnekRepository repo, Snek snek) =>
{
    repo.Create(snek);
    return Results.Created($"/sneks/{snek.Id}", snek);
});

app.MapGet("/sneks", ([FromServices] SnekRepository repo) => repo.GetAll());

app.MapGet("/sneks/{id:int}", ([FromServices] SnekRepository repo, int id) =>
{
    var snek = repo.GetById(id);
    return snek is not null ? Results.Ok(snek) : Results.NotFound();
});

app.MapPut("/sneks/{id:int}", ([FromServices] SnekRepository repo, int id, Snek updatedSnek) =>
{
    var snek = repo.GetById(id);
    if (snek is null)
        return Results.NotFound();
    
    repo.Update(updatedSnek);
    return Results.Ok(updatedSnek);
});

app.MapDelete("/sneks/{id:int}", async ([FromServices] SnekRepository repo, int id) =>
{
    await Task.Delay(1000);
    repo.Delete(id);
    return Results.Ok();
});

app.Run();