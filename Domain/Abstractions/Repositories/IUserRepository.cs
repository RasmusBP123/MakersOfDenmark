using Domain.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsEmailOrUsernameTaken(ApplicationUser user);
    }
}
