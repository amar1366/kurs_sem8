using lab4.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Manager.Universities
{
    public interface InterfaceUManager
    {
        Task<University> AddUniversity(Guid DepartamentId, URequest request);
        Task<University> UpdateUniversity(Guid id, URequest request);
        Task<Guid> DeleteUniversity(Guid id);
        Task<University> GetById(Guid id);
        Task<University> GetAllProfessors(Guid id);
        Task<University> Searchprofessor(Guid id, string name, string text);
    }
}
