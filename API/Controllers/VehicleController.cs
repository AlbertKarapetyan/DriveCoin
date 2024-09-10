using API.Models;
using Common;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Create new vehicle
        [HttpPost("Create")]
        public async Task<IActionResult> CreateVehicle(CreateVehicleModel createVehicleModel)
        {
            try
            {
                var result = await _mediator.Send(new CreateVehicleCommand(createVehicleModel.UserId, createVehicleModel.TransportId));

                return Ok(result);
            }
            catch(DriveException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Get vehicle by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _mediator.Send(new GetVehicleQuery(id));
                if (vehicle == null)
                {
                    return NotFound();
                }

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
