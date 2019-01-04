using Ballicon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ballicon.API.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetUsersAsync();
    }
}
