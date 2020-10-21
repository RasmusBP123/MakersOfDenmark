using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IProfileRepository
    {
        Task<IdentityResult> DeleteUser(string userId);
    }
}
