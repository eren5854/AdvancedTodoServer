using AdvancedTodoServer.WebAPI.Abstractions;
using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedTodoServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class UsersController(
    IUserService userService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserDto request, CancellationToken cancellationToken)
    {
        var response = await userService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await userService.GetById(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await userService.Delete(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
