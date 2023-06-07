using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("getModelById")]
        public IActionResult getmodelById(Guid id)
        {
            var result = _modelService.GetById(id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }

        [HttpGet("getAllModels")]
        public IActionResult getAllmodels()
        {
            var result = _modelService.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest();
        }
        [HttpDelete("deleteModel")]
        public IActionResult deletemodel(Model model)
        {
            var result = _modelService.Delete(model);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPatch("updateModel")]
        public IActionResult updatemodel(Model model)
        {
            var result = _modelService.Update(model);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost("addModel")]
        public IActionResult addmodel(Model model)
        {
            var result = _modelService.Update(model);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
