using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions;

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
        _context.Profiles.Add(profile);
        await _context.SaveChangesAsync();
    }

    public async Task<Profile?> GetByUserIdAsync(string userId)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(p => p.UserId == userId);
    }
}