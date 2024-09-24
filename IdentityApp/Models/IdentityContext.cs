using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models;
public class IdentityContext : IdentityDbContext<AppUser,AddRole,string>
{
    public IdentityContext (DbContextOptions<IdentityContext> options) :base(options)
    {
        
    }
}