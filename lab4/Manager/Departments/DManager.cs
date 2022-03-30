using lab4.Storage.Entity;
using lab4.Storage.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab4.Manager.Departments
{
    public class DManager : InterfaceDManager
    {
        public readonly CenterDataContext _dbContext;

        public DManager(CenterDataContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<Department> AddDepartment(DRequest request)
        {
            var entity = new Department
            {
                dNomber = Guid.NewGuid(),
                dName = request.dName
            };
            _dbContext.Department.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Department> UpdateDepartment(Guid id, DRequest request)
        {
            var entity = await _dbContext.Department.FirstOrDefaultAsync(g => g.dNomber == id);
            entity.dName = request.dName;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Department> DeleteDepartment(Guid id)
        {
            var entity = await _dbContext.Department.FirstOrDefaultAsync(g => g.dNomber == id);
            _dbContext.Department.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }
        public async Task<Department> GetById(Guid id)
        {
            return await _dbContext.Department.FirstOrDefaultAsync(g => g.dNomber == id);
        }
        public async Task<Department> GetAllUniversity(Guid id)
        {
            var entity = await _dbContext.Department.FirstOrDefaultAsync(g => g.dNomber == id);
            entity.Universities = await _dbContext.University.AsNoTracking().Where(g => g.DepartamentId == id).ToListAsync();
            return entity;
        }
        public async Task<List<Department>> GetAllDepartment()
        {
            return await _dbContext.Department.AsNoTracking().ToListAsync();
        }
        
    }
}
