var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//MVC Şablonu

var app = builder.Build();
// {controller}/{action}/{id?}
//app.MapDefaultControllerRoute();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
