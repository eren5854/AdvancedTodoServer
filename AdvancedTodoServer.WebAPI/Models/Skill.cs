using AdvancedTodoServer.WebAPI.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTodoServer.WebAPI.Models;
[Table("skills")]
public sealed class Skill : Entity
{
    public int Strength { get; set; } = 0;
    public int Intelligence { get; set; } = 0;
    public int Charisma { get; set; } = 0;
    public int Creativity { get; set; } = 0;
}
