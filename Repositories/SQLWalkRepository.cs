using HEWalks.API.Data;
using HEWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HEWalks.API.Repositories
{
	public class SQLWalkRepository : IWalkRepository
	{
		private readonly HEWalksDbContext dbContext;

		public SQLWalkRepository(HEWalksDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<Walk> CreateAsync(Walk walk)
		{
			await dbContext.Walks.AddAsync(walk);
			await dbContext.SaveChangesAsync();
			return walk;
		}

		public async Task<List<Walk>> GetAllAsync()
		{
			return await dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync();		
		}
	}
}
