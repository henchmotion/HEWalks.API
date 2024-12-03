using Microsoft.EntityFrameworkCore;
using HEWalks.API.Models.Domain;

namespace HEWalks.API.Data
{
    public class HEWalksDbContext:DbContext
    {
        public HEWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}

