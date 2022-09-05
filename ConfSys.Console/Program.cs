using ConfSys.Domain.Entity;
using ConfSys.Domain.Enum;
using ConfSys.Service.Implement;
using ConfSys.Service.Interface;

IUserService userService = new UserService();
//await userService.CreateAsync(new User
//{
//    Email = "Reza.r@gmail.com",
//    Family = "Mohammadi",
//    Gender = Gender.Male,
//    Name = "Reza",
//    OriginId = 3,
//});
//var resutl = await userService.LoginAsync("mha.karimi@gmail.com", "418443");
IProjectService projectService = new ProjectService();

//await projectService.DeleteAsync(4, 4);
await projectService.CreateProjectAsync(new Project
{
    UserId = 12,
    Name = "Visual",
    Website = "Twiter"
});
//await userService.DeleteUserAsync(10);
//await userService.DeleteUserAsync(11);

Console.ReadLine();