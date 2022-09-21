#nullable disable
using System.Text.Json.Serialization;

namespace ConfSys.Domain.Entity;

[Table(nameof(Project), Schema = nameof(Schema.Base))]
public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public int UserId { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    [Required]
    [MaxLength(75)]
    public string Website { get; set; }

    [JsonIgnore]
    public ICollection<Members> Members { get; set; }
}
