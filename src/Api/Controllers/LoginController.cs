using Application.UseCases.Login;
using Application.UseCases.Login.DoLogin;
using Contracts.Communication.Errors.Responses;
using Contracts.Communication.Login.Requests;
using Contracts.Communication.Users.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromServices] IDoLoginUseCase useCase,
        [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}