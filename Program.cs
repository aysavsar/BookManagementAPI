using BookManagementAPI.Mappings;
using BookManagementAPI.Services;
using BookManagementAPI.Services.Interfaces;
using BookManagementAPI.Validators;
using FluentValidation;
using BookManagementAPI.Data; // ApplicationDbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper configuration
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<BookProfile>(), typeof(Program));

// Add FluentValidation configuration
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Add DbContext configuration for PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // PostgreSQL

// Register application services
builder.Services.AddScoped<IBookService, BookService>();

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
