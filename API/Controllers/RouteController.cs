using API.Models;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Create new route
        [HttpPost("Create")]
        public async Task<IActionResult> CreateRoute(CreateRouteModel createRouteModel)
        {
            try
            {
                var result = await _mediator.Send(new CreateRouteCommand(createRouteModel.Name, 
                                                                         createRouteModel.ACityId, 
                                                                         createRouteModel.BCityId, 
                                                                         createRouteModel.TimeDelay));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Get route by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoute(int id)
        {
            try
            {
                var route = await _mediator.Send(new GetRouteQuery(id));
                if (route == null)
                {
                    return NotFound();
                }

                return Ok(route);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
