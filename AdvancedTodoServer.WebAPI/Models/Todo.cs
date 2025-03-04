using AdvancedTodoServer.WebAPI.Abstractions;
using AdvancedTodoServer.WebAPI.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdvancedTodoServer.WebAPI.Models;
[Table("todos")]
public sealed class Todo : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public SkillEnum Skill { get; set; }

    public Guid UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
}
