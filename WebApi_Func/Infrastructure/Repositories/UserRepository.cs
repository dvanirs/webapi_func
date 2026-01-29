using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_Func.Domain.Entities;
using WebApi_Func.Domain.Interfaces;
using WebApi_Func.Infrastructure.Context;

namespace WebApi_Func.Infrastructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de usuários utilizando Entity Framework Core.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        /// <summary>
        /// Obtém todos os usuários com paginação e ordenação simples.
        /// </summary>
        public async Task<IEnumerable<User>> GetAllAsync(int page, int pageSize, string sortOrder)
        {
            var query = _context.Users.AsQueryable();

            // Simple sorting
            query = sortOrder?.ToLower() switch
            {
                "name" => query.OrderBy(u => u.Nome),
                "name_desc" => query.OrderByDescending(u => u.Nome),
                _ => query.OrderBy(u => u.Id),
            };

            
            if (pageSize > 0)
            {
                query = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
