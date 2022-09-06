#nullable disable
namespace ConfSys.Domain.Entity;

[Table(nameof(User), Schema = nameof(Schema.Base))]

public class User
{
    [Key]
    public int UserId { get; set; }

    [ForeignKey(nameof(OriginId))]
    public Origin Origin { get; set; }
    public int OriginId { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Family { get; set; }

    public Gender Gender { get; set; }

    [Required]
    [MaxLength(75)]
    public string Email { get; set; }

    [Required]
    [MaxLength(25)]
    public string Password { get; set; }

    public ICollection<Project> Projects { get; set; }
    public ICollection<FamilyMember> FamilyMembers { get; set; }
    public ICollection<Members> Members { get; set; }
}
