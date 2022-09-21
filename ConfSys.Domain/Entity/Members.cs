#nullable disable
using System.Text.Json.Serialization;

namespace ConfSys.Domain.Entity;

[Table(nameof(Members), Schema = nameof(Schema.Base))]

public class Members
{
    [Key]
    public int MembersId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public int? UserId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
    public int ProjectId { get; set; }

    [Required]
    public DateTime Engagement { get; set; }

    [Required]
    [MaxLength(25)]
    public string Position { get; set; }

    [Required]
    public DateTime EndOfEngagement { get; set; }

}
