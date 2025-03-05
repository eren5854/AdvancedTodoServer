using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Enum;
using AdvancedTodoServer.WebAPI.Models;
using AdvancedTodoServer.WebAPI.Repositories;
using AutoMapper;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Services;

public sealed class TodoService(
    ITodoRepository todoRepository,
    IUserRepository userRepository,
    IMapper mapper) : ITodoService
{
    public async Task<Result<string>> Create(CreateTodoDto request, CancellationToken cancellationToken)
    {
        Todo todo = mapper.Map<Todo>(request);
        todo.IsCompleted = false;
        todo.CreatedDate = DateTime.Now;
        return await todoRepository.Create(todo, cancellationToken);
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await todoRepository.Delete(id, cancellationToken);
    }

    public async Task<Result<List<Todo>>> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await todoRepository.GetByUserId(userId, cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateTodoDto request, CancellationToken cancellationToken)
    {
        Todo? todo = todoRepository.GetById(request.Id);
        if (todo is null)
        {
            return Result<string>.Failure("Todo not found");
        }

        mapper.Map(request, todo);
        todo.UpdatedDate = DateTime.Now;
        return await todoRepository.Update(todo, cancellationToken);
    }

    public async Task<Result<string>> UpdateStatus(Guid id, CancellationToken cancellationToken)
    {
        Todo? todo = todoRepository.GetById(id);
        if (todo is null)
        {
            return Result<string>.Failure("Todo not found");
        }

        todo.IsCompleted = !todo.IsCompleted;

        User? user = userRepository.GetById(todo.UserId);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        if (todo.IsCompleted)
        {
            user.XP = user.XP + 10;
            if (user.XP == 100)
            {
                user.XP = 0;
                user.Level = user.Level + 1;
            }
            if (todo.Skill == SkillEnum.Strength)
            {
                user.Skill.Strength = user.Skill.Strength + 10;
            }
            else if (todo.Skill == SkillEnum.Intelligence)
            {
                user.Skill.Intelligence = user.Skill.Intelligence + 10;
            }
            else if(todo.Skill == SkillEnum.Charisma)
            {
                user.Skill.Charisma = user.Skill.Charisma + 10;
            }
            else if(todo.Skill == SkillEnum.Creativity)
            {
                user.Skill.Creativity = user.Skill.Creativity + 10;
            }
        }
        else
        {
            user.XP = user.XP - 10;
            if (user.XP < 0)
            {
                user.XP = 90;
                user.Level = user.Level - 1;
            }
            if (todo.Skill == SkillEnum.Strength)
            {
                user.Skill.Strength = user.Skill.Strength - 10;
            }
            else if (todo.Skill == SkillEnum.Intelligence)
            {
                user.Skill.Intelligence = user.Skill.Intelligence - 10;
            }
            else if (todo.Skill == SkillEnum.Charisma)
            {
                user.Skill.Charisma = user.Skill.Charisma - 10;
            }
            else if (todo.Skill == SkillEnum.Creativity)
            {
                user.Skill.Creativity = user.Skill.Creativity - 10;
            }
        }

        await userRepository.Update(user, cancellationToken);
        return await todoRepository.Update(todo, cancellationToken);
    }
}
