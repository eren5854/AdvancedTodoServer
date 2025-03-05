namespace AdvancedTodoServer.WebAPI.DTOs;

public sealed record UpdateUserDto(
    Guid Id,
    string UserName,
    string Password,
    string Avatar
);
