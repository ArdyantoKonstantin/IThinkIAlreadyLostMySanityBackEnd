using MarvelEntity.Entity;
using MarvelServices.Interface;
using MarvelServices.Options;
using MarvelServices.RequestService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("ExamDB");

builder.Services.Configure<MinIoOptions>(builder.Configuration.GetSection("MinIO"));

builder.Services.AddSingleton<IStorageProvider, MinioService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCinemaHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BlobInformationHandler).Assembly));

builder.Services.AddDbContext<ExamDbContext>(dbcontextBuilder =>
{
    dbcontextBuilder.UseNpgsql(connString).UseSnakeCaseNamingConvention();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
