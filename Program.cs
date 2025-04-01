using BookManagementAPI.Mappings;
using BookManagementAPI.Services;
using BookManagementAPI.Services.Interfaces;
using BookManagementAPI.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(BookProfile));

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Register services
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();