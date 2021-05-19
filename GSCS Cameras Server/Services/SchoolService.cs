using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using GSCS_Cameras_Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GSCS_Cameras_Server.Services
{
    public class SchoolService : IEntityService<School>
    {
        private ApplicationDbContext _context;
        public SchoolService(ApplicationDbContext context)
        {
            _context = context;
        }
        public School Get(int Id)
        {
            return _context.Schools
                .Include(s => s.Cameras)
                .FirstOrDefault(s => s.Id == Id);
        }

        public async Task<School> GetAsync(int Id)
        {
            var school = await _context.Schools
                .Include(s => s.Cameras)
                .FirstOrDefaultAsync(s => s.Id == Id);
            return school;
        }

        public IEnumerable<School> GetAll()
        {
            return _context.Schools
                .Include(s => s.Cameras)
                .ToList();
        }

        public async Task<IEnumerable<School>> GetAllAsync()
        {
            return await _context.Schools
                .Include(s => s.Cameras)
                .ToListAsync();
        }

        public School Add(School item)
        {
            _context.Schools.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<School> AddAsync(School item)
        {
            await _context.Schools.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public void Remove(School item)
        {
            _context.Schools.Remove(item);
            _context.SaveChanges();
        }
    }
}