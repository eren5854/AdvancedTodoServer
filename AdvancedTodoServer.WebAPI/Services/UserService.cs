using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;
using AdvancedTodoServer.WebAPI.Repositories;
using AutoMapper;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Services;

public sealed class UserService(
    IUserRepository userRepository,
    IMapper mapper) : IUserService
{
    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await userRepository.Delete(id, cancellationToken);
    }

    public async Task<Result<User>> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await userRepository.GetById(id, cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateUserDto request, CancellationToken cancellationToken)
    {
        User? user = userRepository.GetById(request.Id);
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        if (user.UserName != request.UserName)
        {
            bool isUserNameExists = userRepository.IsUserNameExists(request.UserName, cancellationToken);
            if (isUserNameExists)
            {
                return Result<string>.Failure("User name already exists");
            }
        }

        mapper.Map(request, user);
        user.UpdatedDate = DateTime.Now;

        return await userRepository.Update(user, cancellationToken);
    }
}
