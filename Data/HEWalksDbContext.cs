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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            // Seed data for Difficulites
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("39de6daf-ba70-451d-8f8a-1457c27c2535"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("3a5f8381-dc91-4c42-81b6-b141ab13fe86"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("a05591ce-005c-43bc-95e8-82519ccc057d"),
                    Name = "Hard"
                }
            }; 


		}
	}
}

