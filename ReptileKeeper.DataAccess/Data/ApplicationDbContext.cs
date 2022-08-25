using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReptileKeeper.Core.Models;
using ReptileKeeper.Core.Models.Achievements.Trophies;
using ReptileKeeper.Core.Models.Areas.Identity.Account;

namespace ReptileKeeper.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<FeedingLog> FeedingLogs { get; set; }
        public DbSet<PreyItem> PreyItems { get; set; }
        public DbSet<Reptile> Reptiles { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }
    }
}