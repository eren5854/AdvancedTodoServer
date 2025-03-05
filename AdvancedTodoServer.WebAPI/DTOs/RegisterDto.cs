namespace AdvancedTodoServer.WebAPI.DTOs;

public sealed record RegisterDto(
    string UserName,
    string Password,
    string Avatar);
