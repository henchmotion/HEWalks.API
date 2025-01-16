using HEWalks.API.Models.Domain;

namespace HEWalks.API.Repositories
{
	public interface IWalkRepository
	{
		Task<Walk> CreateAsync(Walk walk);
	}
}
