using Application.UseCases.Users.Profiles;
using Application.UseCases.Users.Register;
using Contracts.Communication.Errors.Responses;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [Route("{usernameOrEmail}")]
    [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserProfile(
        [FromServices] IGetUserProfileUseCase useCase,
        [FromRoute] string usernameOrEmail)
    {
        var response = await useCase.Execute(usernameOrEmail);
        return Ok(response);
    }
}