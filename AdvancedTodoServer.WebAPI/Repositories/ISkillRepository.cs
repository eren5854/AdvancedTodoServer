using AdvancedTodoServer.WebAPI.Models;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Repositories;

public interface ISkillRepository
{
    public Task<Result<string>> Create(Skill skill, CancellationToken cancellationToken);
    public Task<Result<string>> Update(Skill skill, CancellationToken cancellationToken);
}
