using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;

namespace AdvancedTodoServer.WebAPI.Services;

public interface IJwtProvider
{
    Task<LoginResponseDto> CreateToken(User user);
}
