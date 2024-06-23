using Microsoft.AspNetCore.Identity;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Concrete;
using StudentManagementSystem.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890_";

    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);
    options.Lockout.MaxFailedAccessAttempts = 3;


}).AddDefaultTokenProviders()
  .AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/auth/login");
    CookieBuilder cookieBuilder = new();
    cookieBuilder.Name = "IdentityCookie";
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);

    // Istifadeci 60 gun boyunca sayta girdikde her defe cookie'nin muddetini 60 gun uzadir
    opt.SlidingExpiration = true;

});
// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
