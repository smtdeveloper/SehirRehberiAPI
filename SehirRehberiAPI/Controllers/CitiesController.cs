using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SehirRehberiAPI.DataAccess;
using SehirRehberiAPI.Dtos;
using SehirRehberiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class CitiesController : ControllerBase
    {
      
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository appRepository, IMapper mapper )
        {
            _appRepository = appRepository;
            _mapper = mapper;
            
        }

        [HttpGet("getall")]
        public ActionResult GetCities()
        {
           var cities = _appRepository.GetCities();
        
          var cityList = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(cityList);
        }

        [HttpPost("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }

    }
}
