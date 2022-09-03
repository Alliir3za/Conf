#nullable disable
using ConfSys.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfSys.Domain.Entity;
[Table(nameof(City),Schema=nameof(Schema.Base))]
public class City
{
    [Key]
    public int CityId { get; set; }
   
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }

}

