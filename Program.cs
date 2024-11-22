

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using test.Data;  // Replace 'test' with your actual project namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add verify services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Welcome"; // Redirect here on login failure
        options.LogoutPath = "/Home/Logout"; // Redirect here on logout
        options.AccessDeniedPath = "/Home/AccessDenied"; // Redirect here on access denied
    });

// Configure the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0)))); // Specify the version of MySQL you are using








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