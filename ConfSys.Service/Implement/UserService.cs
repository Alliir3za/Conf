﻿#nullable disable
using ConfSys.Data;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class UserService : IUserService
{
    private readonly ConfSysDbContext db;
    public UserService()
    {
        db = new ConfSysDbContext();
    }

    public async Task<bool> CreateAsync(User model)
    {
        Random rnd = new();
        model.Password = rnd.Next(1000, 1000000).ToString();

        db.Users.Add(model);
        var result = await db.SaveChangesAsync();
        if (result >= 1)
            return true;

        return false;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var result = await db.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        if (result == null)
            return false;
        db.Users.Remove(result);

        var result_2 = await db.SaveChangesAsync();
        if (result_2 >= 1)
            return true;
        return false;
    }

    public async Task<User> LoginAsync(string email, string password)
    {
        var result = await db.Users.FirstOrDefaultAsync(X => X.Email == email && X.Password == password);
        if (result is null)
            return null;

        return result;
    }
}