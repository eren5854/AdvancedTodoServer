using AdvancedTodoServer.WebAPI.Abstractions;
using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedTodoServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class TodosController(
    ITodoService todoService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoDto request, CancellationToken cancellationToken)
    {
        var response = await todoService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var response = await todoService.GetAllByUserId(userId, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateTodoDto request, CancellationToken cancellationToken)
    {
        var response = await todoService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateStatus(Guid id, CancellationToken cancellationToken)
    {
        var response = await todoService.UpdateStatus(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await todoService.Delete(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
