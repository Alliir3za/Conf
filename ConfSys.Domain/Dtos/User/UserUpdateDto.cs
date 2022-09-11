#nullable disable
namespace ConfSys.Domain.Dtos.User;

public class UserUpdateDto
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public Gender Gender { get; set; }
}
