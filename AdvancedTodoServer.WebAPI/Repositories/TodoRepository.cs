using AdvancedTodoServer.WebAPI.Context;
using AdvancedTodoServer.WebAPI.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace AdvancedTodoServer.WebAPI.Repositories;

public sealed class TodoRepository(
    ApplicationDbContext context) : ITodoRepository
{
    public async Task<Result<string>> Create(Todo todo, CancellationToken cancellationToken)
    {
        await context.Todos.AddAsync(todo, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Todo created successfully");
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        Todo? todo = GetById(id);
        if (todo is null)
        {
            return Result<string>.Failure("Todo not found");
        }

        context.Todos.Remove(todo);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Todo deleted successfully");
    }

    public Todo? GetById(Guid id)
    {
        return context.Todos.Find(id);
    }

    public async Task<Result<List<Todo>>> GetByUserId(Guid userId, CancellationToken cancellationToken)
    {
        List<Todo> todos = await context.Todos.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
        return Result<List<Todo>>.Succeed(todos);
    }

    public async Task<Result<string>> Update(Todo todo, CancellationToken cancellationToken)
    {
        context.Todos.Update(todo);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Todo updated successfully");
    }
}
