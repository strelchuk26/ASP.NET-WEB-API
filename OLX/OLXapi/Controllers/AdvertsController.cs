using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OLXapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertsService service;

        public AdvertsController(IAdvertsService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateAdvertModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            service.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditAdvertModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            service.Edit(model);
            return Ok();
        }

        //[Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
