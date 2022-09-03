#nullable disable
using ConfSys.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfSys.Domain.Entity;
[Table(nameof(Project), Schema = nameof(Schema.Base))]
public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(75)]
    public string WebSite { get; set; }

    [MaxLength(200)]
    public long Description { get; set; }
    public ICollection<User> Users { get; set; }

}
