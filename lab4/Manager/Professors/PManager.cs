using lab4.Storage.Entity;
using lab4.Storage.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Manager.Professors
{
    public class PManager :InterfacePManager
    {
        public readonly CenterDataContext _dbContext;

        public PManager(CenterDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Professor> AddProfessor(Guid UniversityId, PRequest request)
        {
            var entity = new Professor
            {
                pNomber = Guid.NewGuid(),
                surname = request.surname,
                name = request.name,
                middlename = request.middlename,
                birthday = request.MyDay,
                UniversityId = UniversityId
            };
            _dbContext.Professor.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Professor> UpdateProfessor(Guid id, PRequest request)
        {
            var entity = await _dbContext.Professor.FirstOrDefaultAsync(g => g.pNomber == id);
            entity.surname = request.surname;
            entity.name = request.name;
            entity.middlename = request.middlename;
            entity.birthday = request.MyDay;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Guid> DeleteProfessor(Guid id)
        {
            var entity = await _dbContext.Professor.FirstOrDefaultAsync(g => g.pNomber == id);
            _dbContext.Professor.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity.UniversityId;
        }
        public async Task<Professor> GetById(Guid id)
        {
            return await _dbContext.Professor.FirstOrDefaultAsync(g => g.pNomber == id);
        }
    }
}
