

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using test.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Welcome"; 
        options.LogoutPath = "/Home/Logout";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0)))); 








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Change the default route to point to the Welcome action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}"); // Set Welcome as the default action

// lecturer
app.MapControllerRoute(
    name: "lecturerDashboard",
    pattern: "{controller=Home}/{action=LecturerDashboard}/{id?}");



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// check for error submitting claim
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // This helps with detailed error messages during development.
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}







app.Run();
