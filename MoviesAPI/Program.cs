using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoviesAPI;
using MoviesAPI.Data;
using MoviesAPI.Repositories;
using MoviesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"))) ;

var app = builder.Build();

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
