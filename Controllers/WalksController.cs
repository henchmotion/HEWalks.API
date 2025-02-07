
using AutoMapper;
using HEWalks.API.Models.Domain;
using HEWalks.API.Models.DTO;
using HEWalks.API.Models.DTO.Resquest;
using HEWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Prometheus;


namespace HEWalks.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[SwaggerTag("Walks Operations")]

	public class WalksController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IWalkRepository walkRepository;

		public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
			this.mapper = mapper;
			this.walkRepository = walkRepository;
		}

        //CREATE Walk
        //POST: /api/walks
        [HttpPost]
		public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
		{
			//Map DTO to Domain Model
			var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto);

			await walkRepository.CreateAsync(walkDomainModel);

			// Map Domain Model to DTO
			return Ok(mapper.Map<WalkDto>(walkDomainModel));
		}


		//GET Walks
		//GET: /api/walks
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var walkDomainModel = await walkRepository.GetAllAsync();

			//Map Domain Model to DTO
			return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
		}

		// Get walk By Id
		//GET: .api/Walks/{id}
		[HttpGet]
		[Route("{id:Guid}")]

		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var walkDomainModel = await walkRepository.GetByIdAsync(id);

			if (walkDomainModel == null)
			{
				return NotFound();
			}

			// Map Domain Model to DTO
			return Ok(mapper.Map<WalkDto>(walkDomainModel));
		}
		 
	}

}
