using Microsoft.EntityFrameworkCore;
using TesteCI.Repository;
using TesteCI.Repository.Context;
using TesteCI.Repository.Interfaces;
using TesteCI.Service;
using TesteCI.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding service to DbContext in memory
builder.Services.AddDbContext<RadioDbContext>(opt => opt.UseInMemoryDatabase("RadioDb"));

builder.Services.AddTransient<ISongService, SongService>();
builder.Services.AddTransient<ISongRepository, SongRepository>();

var app = builder.Build();

// Initializing database in memory setted in DbContext class
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<RadioDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
