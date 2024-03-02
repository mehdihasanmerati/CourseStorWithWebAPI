using CourseStor.AAA.Infrastructure;
using CourseStor.AAA.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CourseStor.AAA.Infrastructure.ApplicationFeature;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IAuthorizationHandler, AgePolicyRequirementHandler>();
builder.Services.AddScoped<IAuthorizationHandler, AppFeatureRequirementHandler>();
builder.Services.AddDbContext<CourseStoreIdentityContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Course")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(c =>
{
    c.Password.RequiredUniqueChars = 0;
    c.Password.RequireNonAlphanumeric = false;
    c.Password.RequireDigit = false;
    c.Password.RequiredLength = 6;
    c.Password.RequireLowercase = false;
    c.Password.RequireUppercase = false;
    c.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<CourseStoreIdentityContext>()
    .AddPasswordValidator<UserNameInPasswordValidator>()
    .AddPasswordValidator<InvalidPassword<IdentityUser>>()
    .AddUserValidator<CustomUserValidator>();

builder.Services.AddAuthorization(c => c.AddPolicy("IsAdmin", pb =>
{
    pb.RequireRole("Admin").RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "hadi");

    c.AddPolicy("IsMoreThan18Years", pb => pb.Requirements.Add(new AgePolicyRequirement(18)));
    c.AddPolicy("AppFeatureRequirement", pb => pb.Requirements.Add(new AppFeatureRequirement()));

    builder.Services.AddSingleton<ApplicationFeature>(new ApplicationFeature
    {
        FeaturesList = new List<string>
        {
            "EditUser",
            "CreateUser"
        }
    });

}));

var app = builder.Build();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();

//app.UseRouting();


app.Run();
