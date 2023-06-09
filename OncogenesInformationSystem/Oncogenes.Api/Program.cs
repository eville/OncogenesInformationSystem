using Microsoft.EntityFrameworkCore;
using Oncogenes.DAL;
using Oncogenes.DAL.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// write to get connection string from appsettings.json
builder.Services.AddDbContext<OncogenesContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<OncogenesContext>(options => options.UseMySQL(""));
builder.Services.AddScoped<IOncogenesRepository, OncogenesRepository>();

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
