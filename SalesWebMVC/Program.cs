using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SalesWebMVCContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("SalesWebMVCContext"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("SalesWebMVCContext")
        )
    )
);


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
