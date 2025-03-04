using AdvancedTodoServer.WebAPI.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdvancedTodoServer.WebAPI.Models;
[Table("users")]
public sealed class User : Entity
{
    public string FulllName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Avatar { get; set; }
    public int XP { get; set; }
    public int Level { get; set; }


    public object SkillInfo => new
    {
        SkillId = SkillId,
        Strength = Skill.Strength,
        Intelligence = Skill.Intelligence,
        Charisma = Skill.Charisma,
        Creativity = Skill.Creativity
    };

    [JsonIgnore]
    public Guid SkillId { get; set; }
    [JsonIgnore]
    public Skill Skill { get; set; } = default!;
}
