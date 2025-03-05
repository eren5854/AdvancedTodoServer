using AdvancedTodoServer.WebAPI.DTOs;
using ED.Result;

namespace AdvancedTodoServer.WebAPI.Services;

public interface IAuthService
{
    public Task<Result<LoginResponseDto>> Login(LoginDto request, CancellationToken cancellationToken);
    public Task<Result<string>> Register(RegisterDto request, CancellationToken cancellationToken);
}
