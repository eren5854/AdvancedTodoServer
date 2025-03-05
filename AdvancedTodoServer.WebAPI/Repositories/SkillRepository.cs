using AdvancedTodoServer.WebAPI.Context;
using AdvancedTodoServer.WebAPI.Models;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Repositories;

public sealed class SkillRepository(
    ApplicationDbContext context) : ISkillRepository
{
    public async Task<Result<string>> Create(Skill skill, CancellationToken cancellationToken)
    {
        await context.Skills.AddAsync(skill, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Skill created successfully");
    }

    public async Task<Result<string>> Update(Skill skill, CancellationToken cancellationToken)
    {
        context.Skills.Update(skill);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Skill updated successfully");
    }
}
