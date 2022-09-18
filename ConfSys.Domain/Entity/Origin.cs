#nullable disable

namespace ConfSys.Domain.Entity;

[Table(nameof(Origin), Schema = nameof(Schema.Base))]

public class Origin
{
    [Key]
    public int OriginId { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
}