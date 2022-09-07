#nullable disable
namespace ConfSys.Domain.Entity;

[Table(nameof(Project), Schema = nameof(Schema.Base))]
public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public int UserId { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    [Required]
    [MaxLength(75)]
    public string Website { get; set; }
    public ICollection<Members> Members { get; set; }
}
