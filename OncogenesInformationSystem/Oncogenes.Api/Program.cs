using Microsoft.EntityFrameworkCore;
using Oncogenes.DAL;
using Oncogenes.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OncogenesContext>(options => options.UseMySQL("Server=oncogenes-db-server.mysql.database.azure.com; Port=3306; Database=Oncogenes; Uid=oncogenes_db_admin; Pwd=Onkogenai!2023; SslMode=Preferred;"));
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
