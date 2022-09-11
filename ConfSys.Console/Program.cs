using ConfSys.Domain.Entity;
using ConfSys.Domain.Enum;
using ConfSys.Service.Implement;
using ConfSys.Service.Interface;
//init
IUserService userService = new UserService();
//await userService.CreateAsync(new User
//{
//    Name = "hosein",
//    Family = "naeemaie",
//    Gender = Gender.Male,
//    Email = "hosein@gamil.com",
//    OriginId = 2,
//});

//var resutl = await userService.LoginAsync("mha.karimi@gmail.com", "418443");
//IProjectService projectService = new ProjectService();

//await projectService.DeleteAsync(4, 4);
//await projectService.CreateProjectAsync(new Project
//{
//    UserId = 9,
//    Name = "VS code",
//    Website = "Varzesh3"
//});
//await userService.DeleteUserAsync(10);
//await userService.DeleteUserAsync(11);
//IFamilyMemberService familyMemberService = new FamilyMemberService();
//await familyMemberService.CreateFamilyAsync(new FamilyMember
//{
//    UserId = 1,
//    Name = "Yasamin",
//    Family = "Moradi",
//    Age = 45,
//    Gender = Gender.Female,
//    NationalCode = "0016596055",
//    Relation = Relation.Mother,
//});
//await familyMemberService.DeleteFamilyAsync(4);
//await familyMemberService.GetAllFamilyMembersAsync(6);
//IMemberService memberService = new MemberService();
//var result = await memberService.GetList();
IUserService userService1 = new UserService();
var rsult = await userService1.GetAll();
Console.WriteLine(rsult);
Console.ReadLine();