using Microsoft.EntityFrameworkCore;
using Tril_3.Data;
using Tril_3.Repostorys.Cinema;
using Tril_3.Repostorys.Cinemarepo;
using Tril_3.Repostorys.MoviesRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("myconnection");
builder.Services.AddDbContext<dbcontext>(options => options.UseSqlServer(connection));


builder.Services.AddControllers();

builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<ICinemaRepo, CinemaRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
