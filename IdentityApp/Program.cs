using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEMailSender,SmtpEmailSender>(i => 
    new SmtpEmailSender(
        builder.Configuration["EmailSender:Host"]?? "",
        builder.Configuration.GetValue<int>("EmailSender:Port"),
        builder.Configuration.GetValue<bool>("EmailSender:enableSSL"),
        builder.Configuration["EmailSender:Username"]?? "",
        builder.Configuration["EmailSender:Host"]?? "")
        );
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:SQLite_Connection"]));

builder.Services.AddIdentity<AppUser, AddRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => {
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts=5;
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath="/Account/Login";
    options.AccessDeniedPath="/Account/AccessDenied";
    options.SlidingExpiration=true;
    options.ExpireTimeSpan= TimeSpan.FromMinutes(30);
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

IdentitySeedData.IdentityTestUser(app);

app.Run();
