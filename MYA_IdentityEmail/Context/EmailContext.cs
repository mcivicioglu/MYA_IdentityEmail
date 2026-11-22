using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MYA_IdentityEmail.Entities;

namespace MYA_IdentityEmail.Context
{
    public class EmailContext : IdentityDbContext<AppUser>
    {
        public EmailContext(DbContextOptions<EmailContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
