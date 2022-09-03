#nullable disable
using ConfSys.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfSys.Domain.Entity;

[Table(nameof(User), Schema = nameof(Schema.Base))]
public class User
{
    [ForeignKey(nameof(CityId))]
    public City City { get; set; }
    public int CityId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
    public int ProjectId { get; set; }

    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Family { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    [MaxLength(75)]
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; }

}

