using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiraDesign.Models;

namespace MiraDesign.Data.Data
{
    public class MiraDesignContext : IdentityDbContext<MiraDesignUser>
    {
        public MiraDesignContext(DbContextOptions<MiraDesignContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
