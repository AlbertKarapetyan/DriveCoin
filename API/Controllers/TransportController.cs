using API.Models;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Create new transport
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTransport(CreateTransportModel createTransportModel)
        {
            try
            {
                var result = await _mediator.Send(new CreateTransportCommand(createTransportModel.Name,
                                                                             createTransportModel.EngineSize,
                                                                             createTransportModel.PassengersCount,
                                                                             createTransportModel.Price,
                                                                             createTransportModel.ModelId,
                                                                             createTransportModel.AvailableLevel));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Get transport by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransport(int id)
        {
            try
            {
                var transport = await _mediator.Send(new GetTransportQuery(id));
                if (transport == null)
                {
                    return NotFound();
                }

                return Ok(transport);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
