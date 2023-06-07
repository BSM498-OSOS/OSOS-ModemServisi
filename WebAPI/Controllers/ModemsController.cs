using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModemsController : ControllerBase
    {
        private readonly IModemService _modemService;

        public ModemsController(IModemService modemService)
        {
            _modemService = modemService;
        }

        [HttpGet("getModemById")]
        public IActionResult getModemById(Guid id)
        {
            var result = _modemService.GetById(id);
            if(result.Success) 
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getAllModems")]
        public IActionResult getAllModems()
        {
            var result = _modemService.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getModemWithCompleteInfoById")]
        public IActionResult getModemWithCompleteInfoById(Guid id)
        {
            var result = _modemService.GetWithCompleteInfoById(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getAllModemsWithCompleteInfo")]
        public IActionResult getAllModemsWithCompleteInfo()
        {
            var result = _modemService.GetAllWithCompleteInfo();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpDelete("deleteModem")]
        public IActionResult deleteModem(Modem modem) 
        {
            var result = _modemService.Delete(modem);
            if( result.Success )
                return Ok(result);
            return BadRequest();
        }

        [HttpPatch("updateModem")]
        public IActionResult updateModem(Modem modem)
        {
            var result = _modemService.Update(modem);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("addModem")]
        public IActionResult addModem(Modem modem)
        {
            var result = _modemService.Add(modem);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
