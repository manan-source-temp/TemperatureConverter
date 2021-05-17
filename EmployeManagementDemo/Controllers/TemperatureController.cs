using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TemperatureConverter.BLL;

namespace EmployeManagementDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        
        private readonly ITemperatureService _service;
        public TemperatureController(ITemperatureService service)
        {
            _service = service;
           
        }

        [HttpGet("{temperatureValue}/{oldTemperatureType}/{currenTemperatureType}")]        
        [EnableCors("AllowOrigin")]
        [Produces("application/json")]       
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]          
        public async Task<IActionResult> Get(double temperatureValue, string oldTemperatureType, string currenTemperatureType)
        {            
            var res = await _service.TemperatureConverter(temperatureValue, oldTemperatureType, currenTemperatureType);

            if (res == 0)
                return BadRequest("Temperature converter type cannot same");

            if (res == 1)
                return BadRequest("Temperature converter type cannot be null");

            if (res == 2)
                return BadRequest("Please select proper temperature converter type");

            return Ok(res);                        
        }
    }
}