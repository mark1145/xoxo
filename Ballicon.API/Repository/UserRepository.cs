using Ballicon.API.Interfaces;
using Ballicon.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ballicon.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BrightersContext _brightersContext;

        public UserRepository(BrightersContext brightersContext)
        {
            _brightersContext = brightersContext;
        }

        public async Task<List<Users>> GetUsersAsync()
        {
            return await _brightersContext.Users.ToListAsync();

        }
    }
}
