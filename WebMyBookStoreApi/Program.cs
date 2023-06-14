using Microsoft.EntityFrameworkCore;
using WebMyBookStoreApi.Context;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
string connectionString = @"Data Source=JAVIMEGA;User ID=sa;Password=manager;Database=MyBookStore;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;";

var policyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                         builder =>
                         {
                             builder
                               .AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                         });
});

builder.Services.AddDbContext<MyBookStoreDbContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o=> o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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
app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();
