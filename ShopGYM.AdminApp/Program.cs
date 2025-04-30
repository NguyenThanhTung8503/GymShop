using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShopGYM.AdminApp.Services;
using ShopGYM.ViewModels.System.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Razor runtime compilation for development environment
#if DEBUG
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}
#endif

builder.Services.AddHttpClient();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/Forbidden/";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
    });
builder.Services.AddControllersWithViews()
         .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
builder.Services.AddTransient<IUserApiClient, UserApiClient>();



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

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
