using CQRS_Customer_CRUD.Context;
using CQRS_Customer_CRUD.CustomerFeatures.Commands.AddCustomerCammand;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*
builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
        b => b.MigrationsAssembly(typeof(CustomerDbContext).Assembly.FullName))
);
*/
builder.Services.AddDbContext<ICustomerDbContext, CustomerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
        b => b.MigrationsAssembly(typeof(ICustomerDbContext).Assembly.FullName))
);

builder.Services.AddMediatR(typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//region_Swagger

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sample CQRS With MediatR.WebApi",
    });
});
//endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    /*
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/ swagger / v1 / swagger.json", "SampleCQRSwithMediatR.WebApi");
    });
    */
}

app.UseAuthorization();

app.MapControllers();

app.Run();
