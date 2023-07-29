using BLL.Abstract;
using BLL.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddSingleton<ILoginService, LoginService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IPurchaseService, PurchaseService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = "/Login/Index";
                    options.AccessDeniedPath = "/Login/Denied";
                });

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
