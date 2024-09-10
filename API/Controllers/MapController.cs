using API.Models;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Create new map
        [HttpPost("Create")]
        public async Task<IActionResult> CreateMap(CreateMapModel createMapModel)
        {
            try
            {
                var result = await _mediator.Send(new CreateMapCommand(createMapModel.Name, createMapModel.AvailableLevel));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Get map by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMap(short id)
        {
            try
            {
                var map = await _mediator.Send(new GetMapQuery(id));
                if (map == null)
                {
                    return NotFound();
                }

                return Ok(map);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
