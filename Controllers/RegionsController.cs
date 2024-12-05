﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HEWalks.API.Models.Domain;
using HEWalks.API.Data;
using Microsoft.EntityFrameworkCore;
using HEWalks.API.Models.DTO;

namespace HEWalks.API.Controllers
{
    // http://localhost:6860/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly HEWalksDbContext dbContext;
        public RegionsController(HEWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET ALL REGIONS
        // GET: https: //localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from Database - Domain models 

            var regionsDomain = await dbContext.Regions.ToListAsync();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,

                });
            }



            //Return the DTOs to the client
            return Ok(regionsDto);
        }


        //GET REGION BY ID
        //GET:  // GET: https: //localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);

            //Get Region Domain Model From Database
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Region Domain Model to Region DTO
            //

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            //Return DTO back to client
            return Ok(regionDto);


        }

        //POST To Create New Region
        //POST:https: //localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Covert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            // Use Domaiin Model to create Region using DbContext
            await dbContext.Regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();

            // Map Domain moodel back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
        }


        //Update Region
        //PUT: https: //localhost:portnumber/api/regions {id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        { 
            // Check if Region Exists 
           var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map DTO to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;   
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            // Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        //Delete Region
        // DELETE: https: //localhost:portnumber/api/regions {id}

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Delete region
            dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();

            //return deleted Region back
            //map Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);

        }

	}
}


