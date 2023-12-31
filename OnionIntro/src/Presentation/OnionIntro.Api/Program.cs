using FluentValidation.AspNetCore;
using OnionIntro.Application.ServiceRegistration;
using OnionIntro.Application.Validators.CategoryValidators;
using OnionIntro.Persistence.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();/*.AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>());*/
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
