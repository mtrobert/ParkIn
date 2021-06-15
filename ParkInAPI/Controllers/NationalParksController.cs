using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkInAPI.Models;
using ParkInAPI.Models.DTOs;
using ParkInAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkInAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private INationalParkRepository _npRepo;

        private readonly IMapper _mapper;

        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var objList = _npRepo.GetNationalParks();

            var objDtoList = new List<NationalParkDTO>();

            foreach (var item in objList)
            {
                objDtoList.Add(_mapper.Map<NationalParkDTO>(item));
            }

            return Ok(objDtoList);
        }

        [HttpGet("{nationalParkId:int}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var np = _npRepo.GetNationalPark(nationalParkId);
            if(np == null)
            {
                return NotFound();
            }

            var npDto = _mapper.Map<NationalParkDTO>(np);

            return Ok(npDto);
        }

        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_npRepo.NationalParkExists(nationalParkDTO.Name))
            {
                ModelState.AddModelError("", "National Park Already Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NationalPark nationalParkObj = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_npRepo.CreateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when adding the {nationalParkDTO.Name} national park.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetNationalPark", new {nationalParkId = nationalParkObj.Id }, nationalParkObj);
        }
    }
}
