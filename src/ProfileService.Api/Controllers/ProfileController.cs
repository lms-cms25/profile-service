using Microsoft.AspNetCore.Mvc;
using Application.Abstractions;
using Application.Dtos;
using Domain.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ProfileService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileRepository _repository;
    private readonly ClaimsPrincipal? _user;
    public string? UserId;


    public ProfileController(IProfileRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _user = httpContextAccessor.HttpContext?.User;
        UserId = _user?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    // CREATE (optional om du vill stödja ny user)
    [HttpPost]
    public async Task<IActionResult> Create(ProfileDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirst("sub")?.Value;

        Console.WriteLine("UserId: " + userId);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var profile = new Profile
        {
            UserId = userId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Description = dto.Description
        };

        await _repository.AddAsync(profile);

        return Ok(profile);
    }

    // GET
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(string userId)
    {
        var profile = await _repository.GetByUserIdAsync(userId);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }

    // UPDATE
    [HttpPut]
    public async Task<IActionResult> Update(ProfileDto dto)
    {
        var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = await _repository.GetByUserIdAsync(userId);

        if (profile == null)
            return NotFound();

        profile.FirstName = dto.FirstName;
        profile.LastName = dto.LastName;
        profile.Phone = dto.Phone;
        profile.Description = dto.Description;

        await _repository.UpdateAsync(profile);

        return Ok(profile);
    }
}