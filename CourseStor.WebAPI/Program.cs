using CourseStor.BLL.Tags.Commands;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using CourseStor.Models.Frameworks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddSeq();
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();//AddXmlSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CourseStorDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("Course")).AddInterceptors(new AddAuditFieldInterceptor()));
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateTagHandler).Assembly));
builder.Services.AddScoped<ApplicationServiceResponse>();
//builder.Services.AddMediatR(typeof(CreateTagHandler).Assembly);

builder.Services.AddMvc();

builder.Services.Configure<MvcNewtonsoftJsonOptions>(c =>
{
    c.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
    c.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.Configure<MvcOptions>(c =>
{
    c.RespectBrowserAcceptHeader = true;
    c.ReturnHttpNotAcceptable = true;
});

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
