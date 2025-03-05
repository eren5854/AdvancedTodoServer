using AdvancedTodoServer.WebAPI.Enum;

namespace AdvancedTodoServer.WebAPI.DTOs;

public sealed record UpdateTodoDto(
    Guid Id,
    string Title,
    string Description,
    SkillEnum Skill);