using LiStream.DataHandler;
using LiStream.DataHandler.Interfaces;
using LiStream.DtoHandler;
using LiStream.DtoHandler.Interfaces;
using LiStream.Evaluators;
using LiStream.Evaluators.Interfaces;
using LiStreamAPI;
using LiStreamData;
using LiStreamData.Interfaces;
using LiStreamEF;
using LiStreamEF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure the database provider and connection string
builder.Services.AddDbContext<LiStreamContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Register services
builder.Services.AddScoped<IDataWriter, DataWriter>();
builder.Services.AddScoped<IDataReader, DataReader>();
builder.Services.AddScoped<IDataHandler, DataHandler>();
builder.Services.AddSingleton<IDtoHandler, DtoHandler>();
builder.Services.AddSingleton<IEvaluator, Evaluator>();

builder.Services.AddScoped<AlbumHandler>();
builder.Services.AddScoped<ArtistHandler>();
builder.Services.AddScoped<PlaylistHandler>();
builder.Services.AddScoped<SongHandler>();
builder.Services.AddScoped<UserHandler>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers();
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

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
