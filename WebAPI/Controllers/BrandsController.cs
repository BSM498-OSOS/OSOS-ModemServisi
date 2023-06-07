using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getBrandById")]
        public IActionResult getbrandById(Guid id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getAllBrands")]
        public IActionResult getAllbrands()
        {
            var result = _brandService.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }
        [HttpDelete("deleteBrand")]
        public IActionResult deletebrand(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPatch("updateBrand")]
        public IActionResult updatebrand(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("addBrand")]
        public IActionResult addbrand(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
