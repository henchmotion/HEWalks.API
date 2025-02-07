using AutoMapper;
using HEWalks.API.Models.Domain;
using HEWalks.API.Models.DTO;
using HEWalks.API.Models.DTO.Resquest;

namespace HEWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile 
	{
        public AutoMapperProfiles()
        {
			CreateMap<Region, RegionDto>().ReverseMap();
			CreateMap<AddRegionRequestDto, Region>().ReverseMap();
			CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
			CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
			CreateMap<Walk, WalkDto>().ReverseMap();
			CreateMap<Difficulty, DifficultyDto>().ReverseMap();
		}
    }
}
