using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Services;

public interface ITodoService
{
    public Task<Result<string>> Create(CreateTodoDto request, CancellationToken cancellationToken);
    public Task<Result<string>> Update(UpdateTodoDto request, CancellationToken cancellationToken);
    public Task<Result<string>> UpdateStatus(Guid id, CancellationToken cancellationToken);
    public Task<Result<List<Todo>>> GetAllByUserId(Guid userId, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
}
