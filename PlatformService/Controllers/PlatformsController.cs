using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public readonly IPlatformRepo _repository;
        public readonly IMapper _mapper;
        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatforReadDto>> GetPlatforms()
        {
            Console.WriteLine("----> Getting Platforms....");

            var platformItem = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatforReadDto>>(platformItem));

        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatforReadDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatforReadDto>(platformItem));
            }
            else
            {
                return NotFound();
            }
        }
    }
}