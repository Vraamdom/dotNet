using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext DbContext) =>{
    try
    {
        DbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: "+ DbContext.Database.IsInMemory());

    }catch (Exception e){
        return Results.Ok("Error al verificar la base de datos en memoria: " + e.Message);
    }
});

app.Run();
