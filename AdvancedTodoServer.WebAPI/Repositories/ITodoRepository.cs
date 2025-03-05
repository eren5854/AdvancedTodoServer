using AdvancedTodoServer.WebAPI.Models;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Repositories;

public interface ITodoRepository
{
    public Task<Result<string>> Create(Todo todo, CancellationToken cancellationToken);
    public Task<Result<string>> Update(Todo todo, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
    public Todo? GetById(Guid id);
    public Task<Result<List<Todo>>> GetByUserId(Guid userId, CancellationToken cancellationToken);
}
