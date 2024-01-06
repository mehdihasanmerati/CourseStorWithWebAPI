using CourseStor.BLL.Tags.Commands;
using CourseStor.DAL.DbContexts;
using CourseStor.DAL.Frameworks;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CourseStorDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("Course")).AddInterceptors(new AddAuditFieldInterceptor()));
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateTagHandler).Assembly));
//builder.Services.AddMediatR(typeof(CreateTagHandler).Assembly);




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
