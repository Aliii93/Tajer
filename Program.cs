using Microsoft.EntityFrameworkCore;
using TajerTest.Models;

var builder = WebApplication.CreateBuilder(args);

//var Configuration = builder.Configuration;
//builder.Services.AddDbContext<TajerContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString"));
//});
// Add services to the container.
//builder.Services.AddDbContextPool<TajerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnectionString"), o => o.CommandTimeout(60000)));
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
