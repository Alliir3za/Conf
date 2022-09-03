#nullable disable
using ConfSys.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfSys.Domain.Entity;
[Table(nameof(User), Schema = nameof(Schema.Base))]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Family { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(150)]
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; }

}

