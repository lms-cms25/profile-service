using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities;

public class Profile
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Description { get; set; } = null!;
}