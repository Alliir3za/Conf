#nullable disable
using ConfSys.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfSys.Domain.Entity;

[Table(nameof(User), Schema = nameof(Schema.Base))]
public class User
{
    [Key]
    public int UserId { get; set; }

    [ForeignKey(nameof(OriginId))]
    public Origin Origin { get; set; }
    public int OriginId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
    public int ProjectId { get; set; }


    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Family { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required]
    [MaxLength(75)]
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; }

    [Required]
    [MaxLength(25)]
    public string Password { get; set; }

}

