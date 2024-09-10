using API.Models;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Create new city
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCity(CreateCityModel createCityModel)
        {
            try
            {
                var result = await _mediator.Send(new CreateCityCommand(createCityModel.Name, createCityModel.MapId, createCityModel.AvailableLevel));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Get city by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(short id)
        {
            try
            {
                var city = await _mediator.Send(new GetCityQuery(id));
                if (city == null)
                {
                    return NotFound();
                }

                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
