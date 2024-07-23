using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete;
using BloggApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);
});

builder.Services.AddScoped<IPostRepository, EfPostRepositoy>();
builder.Services.AddScoped<ITagRepository, EfTagRepositoy>();
//IpostRepository bir sanal sınıf, bu her çağrıldığında EfPostRepositoy den nesne üretip bize göndericek
//AddScoped => her http isteğinde aynı nesne
var app = builder.Build();//app değişkeni, uygulamanın ayarlarına ve servislerine ulaşmak için kullanılır.
app.UseStaticFiles();
SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/{url}/abc",
    defaults: new { controller = "Posts", action = "Detalis" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
