using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Domain
{
    public interface IUsersDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChanges();
    }
}