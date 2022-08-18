using Microsoft.EntityFrameworkCore;
using NewsPortal.Application;
using NewsPortal.Domain;
using NewsPortal.Infrastrucutre.EntityFrameWork;
using NewsPortal.Networking;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddTransient<INewsAppService, NewsAppService>();
builder.Services.AddTransient<INewsRepository<News>, NewsRepository>();
builder.Services.AddTransient<IRestService, RestService>();
builder.Services.AddDbContext<NewsPortalContext>(options =>
                     options.UseSqlServer("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;"));



// Add services to the container.

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
