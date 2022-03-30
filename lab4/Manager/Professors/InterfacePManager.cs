using lab4.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Manager.Professors
{
    public interface InterfacePManager
    {
        Task<Professor> AddProfessor(Guid UniversityId, PRequest request);
        Task<Professor> UpdateProfessor(Guid id, PRequest request);
        Task<Guid> DeleteProfessor(Guid id);
        Task<Professor> GetById(Guid id);

    }
}
