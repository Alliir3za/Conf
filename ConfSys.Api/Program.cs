using ConfSys.Data;
using ConfSys.Service;
using ConfSys.Service.Implement;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.CaptureStartupErrors(true);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConfSysDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConfSysDbContext"));
});


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IOriginService, OriginService>();

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("Send Message");
    q.AddJob<SendingMessageJob>(opts =>
    opts.WithIdentity(jobKey));
    q.AddTrigger(opts => opts.ForJob(jobKey).WithIdentity($"{jobKey.Name}.trigger").
    WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()));
});

builder.Services.AddQuartz(q =>
{
    q.ScheduleJob<IOriginJob>(opt =>
    {
        opt.StartNow();
    });
});


builder.Services.AddQuartzServer(options =>
{
    options.WaitForJobsToComplete = true;
});


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI((c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "Api")));
app.UseRouting();
app.UseEndpoints(config =>
{
    config.MapControllers();
});
app.Run();