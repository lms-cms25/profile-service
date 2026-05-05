using Microsoft.AspNetCore.Mvc;
using Application.Abstractions;
using Application.Dtos;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProfileService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileRepository _repository;

    public ProfileController(IProfileRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProfileDto dto)
    {
        var profile = new Profile
        {
            UserId = "test123",
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Description = dto.Description
        };

        await _repository.AddAsync(profile);

        return Ok(profile);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(string userId)
    {
        var profile = await _repository.GetByUserIdAsync(userId);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }
}