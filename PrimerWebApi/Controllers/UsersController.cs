using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Model;


namespace PrimerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersDbContext _context;
        public UsersController(IUsersDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChanges();
            return Ok(user.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users =  await _context.Users.ToListAsync();
            if (users == null) return NotFound();
            return Ok(users);
        }
    }
}