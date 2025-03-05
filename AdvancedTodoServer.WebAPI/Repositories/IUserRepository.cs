using AdvancedTodoServer.WebAPI.Models;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Repositories;

public interface IUserRepository
{
    public Task<Result<string>> Create(User user, CancellationToken cancellationToken);
    public Task<Result<string>> Update(User user, CancellationToken cancellationToken);
    public Task<Result<User>> GetById(Guid id, CancellationToken cancellationToken);
    public User? GetByUserName(string userName, CancellationToken cancellationToken);
    public bool IsUserNameExists(string userName, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
    public User? GetById(Guid id);
}
