using AdvancedTodoServer.WebAPI.Context;
using AdvancedTodoServer.WebAPI.Models;
using ED.Result;
using Microsoft.EntityFrameworkCore;

namespace AdvancedTodoServer.WebAPI.Repositories;

public sealed class UserRepository(
    ApplicationDbContext context) : IUserRepository
{
    public async Task<Result<string>> Create(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("User created successfully");
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        User? user = GetById(id);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }
        context.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("User deleted successfully");

    }

    public async Task<Result<User>> GetById(Guid id, CancellationToken cancellationToken)
    {
        User? user = await context.Users.Where(w => w.Id == id).Include(i => i.Skill).Include(i => i.Todos).FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            return Result<User>.Failure("User not found");
        }
        return Result<User>.Succeed(user);
    }

    public User? GetById(Guid id)
    {
        User? user = context.Users.Where(w => w.Id == id).Include(i => i.Skill).Include(i => i.Todos).FirstOrDefault();
        if (user is null)
        {
            throw new ArgumentException("User not found");
        }
        return user;
    }

    public User? GetByUserName(string userName, CancellationToken cancellationToken)
    {
        User? user = context.Users.SingleOrDefault(s => s.UserName == userName);
        return user;
    }

    public bool IsUserNameExists(string userName, CancellationToken cancellationToken)
    {
        bool user = context.Users.Any(a => a.UserName == userName);
        return user;
    }

    public async Task<Result<string>> Update(User user, CancellationToken cancellationToken)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("User updated successfully");
    }
}
