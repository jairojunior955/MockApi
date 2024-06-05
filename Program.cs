using MockApi.Services;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
if (string.IsNullOrEmpty(apiBaseUrl))
{
    throw new InvalidOperationException("API_BASE_URL environment variable is not set.");
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<CategoryService>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
