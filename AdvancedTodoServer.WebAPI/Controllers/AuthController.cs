using AdvancedTodoServer.WebAPI.Abstractions;
using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedTodoServer.WebAPI.Controllers;

public sealed class AuthController(
    IAuthService authService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        var response = await authService.Login(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
    {
        var response = await authService.Register(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
