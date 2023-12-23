using MediatorDesign.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDesign.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new InsertUserCommand(request.FirstName, request.LastName, request.UserName, request.Password));

                if (result.Succeeded)
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = result.Data.Id }, result.Data);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest(request);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateUserCommand(id, request.FirstName, request.LastName));

                if (result.Succeeded)
                {
                    return Ok(result.Data);
                }
                else
                {
                    BadRequest(result.Errors);
                }
            }
            return BadRequest(request);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (result.Succeeded)
            {
                return Ok(new { Message = "User Deleted" });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
