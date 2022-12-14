using ConfSys.Data;
using ConfSys.Service.Implement;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.CaptureStartupErrors(true);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddDbContext<ConfSysDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConfSysDbContext"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IOriginService, OriginService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseRouting();
app.UseEndpoints(config =>
{
    config.MapControllers();
});
app.Run();