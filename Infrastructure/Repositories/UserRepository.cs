using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext context;

        public UserRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsEmailOrUsernameTaken(ApplicationUser newUser)
        {
            var users = await context.Users.ToListAsync();
            if(users == null)
                return false;

            foreach (var existingUser in users)
            {
                if (existingUser.Email == newUser.Email || existingUser.UserName == newUser.UserName)
                    return true;
            }

            return false;
        }

    }
}
