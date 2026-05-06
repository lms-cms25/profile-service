using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos;

public class ProfileDto
{
    //public string UserId { get; set; } = User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Description { get; set; } = null!;
}