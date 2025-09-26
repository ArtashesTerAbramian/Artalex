using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models;

public class UserRole : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    public string RoleName { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}