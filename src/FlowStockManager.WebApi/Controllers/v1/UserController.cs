using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Requests.UserRequests;
using Microsoft.AspNetCore.Mvc;

namespace FlowStockManager.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class UserController : ControllerBase
    {
        public async Task<IActionResult> Register([FromServices]ICreateUserCommand command, [FromBody]CreateUserRequest request)
        {
            await command.ExecuteAsync(request);
            return NoContent();
        }
    }
}
