namespace Application.Dtos;

public class ProfileDto
{
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Description { get; set; } = null!;
}