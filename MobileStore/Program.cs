using Microsoft.EntityFrameworkCore;
using MobileStore.Models;
using MobileStore.Services;
using MobileStore.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MobileContext>(options => options.UseSqlite(connection));
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IFeedBackService, FeedBackService>();

// MiddleWare
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseExceptionHandler("/Error/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Phones}/{action=Phones}/{id?}");

app.Run();