using API.Models;
using Data.Entities;
using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Create new user
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUserModel createUserModel)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserCommand(createUserModel.ExternalId,
                                                                        createUserModel.UserName,
                                                                        createUserModel.RefId,
                                                                        createUserModel.IsPremium));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Get all users
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                /*var result = await _mediator.Send(new CreateUserCommand(createUserModel.ExternalId,
                                                                        createUserModel.UserName,
                                                                        createUserModel.RefId,
                                                                        createUserModel.IsPremium));*/

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            /*var users = _userService.GetAllUsers();
            return Ok(users);*/
        }

        // GET: Get user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserQuery(id));
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpGet("search")]
        public IActionResult FindUsers([FromQuery] string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username query parameter is required.");
            }

            Expression<Func<User, bool>> predicate = user => user.UserName.Contains(username);
            var users = _userService.FindUsers(predicate);

            return Ok(users);
        }*/
    }
}
