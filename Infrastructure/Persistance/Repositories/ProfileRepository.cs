using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace Infrastructure.Persistance.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly AppDbContext _context;
    public ProfileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Profile profile)
    {

        await _context.Profiles.AddAsync(profile);
        await _context.SaveChangesAsync();
    }

    public async Task<Profile?> GetByUserIdAsync(string userId)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task UpdateAsync(Profile profile)
    {
        var existing = await _context.Profiles
            .FirstOrDefaultAsync(x => x.UserId == profile.UserId);

        if (existing == null)
            return;

        existing.FirstName = profile.FirstName;
        existing.LastName = profile.LastName;
        existing.Phone = profile.Phone;
        existing.Description = profile.Description;

        _context.Profiles.Update(existing);

        await _context.SaveChangesAsync();
    }
}