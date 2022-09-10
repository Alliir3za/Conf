#nullable disable
namespace ConfSys.Domain.Dtos;

public class UserList
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public Relation Relation { get; set; }
}
