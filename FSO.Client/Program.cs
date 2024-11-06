using Microsoft.EntityFrameworkCore;
using FSO.Client.Services;
using FSO.Client.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<MembersApiService>();


builder.Configuration.AddJsonFile("secrets.json",
        optional: true,
        reloadOnChange: true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ClientDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:DefaultConnection")));
    
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
