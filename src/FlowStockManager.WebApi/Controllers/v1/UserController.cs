using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Requests.UserRequests;
using Microsoft.AspNetCore.Mvc;

namespace FlowStockManager.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class UserController : ControllerBase
    {
        [HttpGet("{id:int:required}")]
        public async Task<IActionResult> GetById([FromServices] IGetUserByIdQuery query, [FromRoute] string id)
        {
            var users = await query.ExecuteAsync(id);
            return Ok(users);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register([FromServices] ICreateUserCommand command, [FromBody] CreateUserRequest request)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update([FromServices] IUpdateUserCommand command, [FromBody] UpdateUserRequest request)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }

        [HttpDelete("DisableUser")]
        public async Task<IActionResult> Disable([FromServices] IDisableUserCommand command, [FromRoute] string id)
        {
            await command.ExecuteAsync(id);
            return NoContent();
        }
    }
}
