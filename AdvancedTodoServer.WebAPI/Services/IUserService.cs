using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Services;

public interface IUserService
{
    public Task<Result<string>> Update(UpdateUserDto request, CancellationToken cancellationToken);
    public Task<Result<User>> GetById(Guid id, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
}
