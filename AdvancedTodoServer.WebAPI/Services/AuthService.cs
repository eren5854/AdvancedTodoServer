using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;
using AdvancedTodoServer.WebAPI.Repositories;
using AutoMapper;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Services;

public class AuthService(
    IUserRepository userRepository,
    ISkillRepository skillRepository,
    IJwtProvider jwtProvider,
    IMapper mapper) : IAuthService
{
    public async Task<Result<LoginResponseDto>> Login(LoginDto request, CancellationToken cancellationToken)
    {
        User? user = userRepository.GetByUserName(request.UserName, cancellationToken);
        if (user is null)
        {
            return Result<LoginResponseDto>.Failure("User not found");
        }

        if (user.Password != request.Password)
        {
            return Result<LoginResponseDto>.Failure("Invalid password");
        }

        var loginResponse = await jwtProvider.CreateToken(user);
        return loginResponse;
    }

    public async Task<Result<string>> Register(RegisterDto request, CancellationToken cancellationToken)
    {
        bool isUserNameExists = userRepository.IsUserNameExists(request.UserName, cancellationToken);
        if (isUserNameExists)
        {
            return Result<string>.Failure("User name already exists");
        }

        Skill skill = new()
        {
            Strength = 0,
            Intelligence = 0,
            Charisma = 0,
            Creativity = 0,
            CreatedDate = DateTime.Now
        };

        User user =  mapper.Map<User>(request);
        user.Skill = skill;
        user.CreatedDate = DateTime.Now;

        return await userRepository.Create(user, cancellationToken);
    }
}
