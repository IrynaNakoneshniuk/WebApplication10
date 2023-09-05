using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication10.Models;
using WebApplMVC_EntityFramework.Services;
using WebApplMVC_EntityFrameworkDZ.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BooksContext>(option=>
option.UseSqlServer("name=ConnectionString:DefaultString"));
builder.Services.AddTransient<IDatabaseHandlerRepository, DatabaseHandler>();
builder.Services.AddTransient<IBooksPageSorterFilter, BooksPageSorterFilter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
