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

            // To seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regios
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id =  Guid.Parse("49cd0653-4674-4cf5-af26-a578a8137edd"),

					Code = "AKL" ,
                    Name =  "Auckland",
                    RegionImageUrl = "img-aucland.url"
                },

				new Region()
				{
					Id = Guid.Parse("868b8f33-8fff-4a39-8cfd-685299f3b672") ,
					Code = "NGN",
					Name ="Nigeria" ,
					RegionImageUrl = "img-nigeria.url"
				},

				new Region()
				{
					Id = Guid.Parse ("edaa6e88-42b2-4a1e-a5ee-958072ff9480"),
					Code = "STL",
					Name = "Scotland",
					RegionImageUrl = "img-stland.url"
				}

			};

            modelBuilder.Entity<Region>().HasData(regions); 

		}
	}
}

