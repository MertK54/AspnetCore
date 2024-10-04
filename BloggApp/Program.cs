using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BloggApp.Data.Abstract;
using BloggApp.Data.Concrete;
using BloggApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionStrings = config.GetConnectionString("mysql_connection");
    var version = new MySqlServerVersion(new Version(8,0,39));
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings)); 
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepositoy>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepositoy>();
builder.Services.AddScoped<IUserRepository, EfUserRepositoy>();
builder.Services.AddScoped<EmailService>();

//IpostRepository bir sanal sınıf, bu her çağrıldığında EfPostRepositoy den nesne üretip bize göndericek
//AddScoped => her http isteğinde aynı nesne
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Users/Login";
});

var app = builder.Build();//app değişkeni, uygulamanın ayarlarına ve servislerine ulaşmak için kullanılır.
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new { controller = "Posts", action = "Details" }
);

app.MapControllerRoute(
    name: "post_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller = "Posts", action = "Index" }
);
app.MapControllerRoute(
    name: "user_profile",
    pattern: "profile/{username}",
    defaults: new { controller = "Users", action = "Profile" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
