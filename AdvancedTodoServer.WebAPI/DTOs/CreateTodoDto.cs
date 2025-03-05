using AdvancedTodoServer.WebAPI.Enum;

namespace AdvancedTodoServer.WebAPI.DTOs;

public sealed record CreateTodoDto(
    string Title,
    string Description,
    SkillEnum Skill,
    Guid UserId
);