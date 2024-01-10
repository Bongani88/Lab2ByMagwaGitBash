using Lab2.CommonModules.Interface;
using Lab2.Infrastructure.Repoistory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<ICustomer, CustomerRepo>();
builder.Services.AddSingleton<IOrder, OrderRepo>();
builder.Services.AddSingleton<IOrderItem, OrderItemRepo>();
builder.Services.AddSingleton<IProduct, ProductRepo>();
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
