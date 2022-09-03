#nullable disable
using ConfSys.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfSys.Domain.Entity;

[Table(nameof(Origin), Schema = nameof(Schema.Base))]
public class Origin
{
    [Key]
    public int OriginId { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
}

