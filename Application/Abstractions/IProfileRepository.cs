using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Abstractions;

public interface IProfileRepository
{
    Task AddAsync(Profile profile);
    Task<Profile?> GetByUserIdAsync(string userId);
}