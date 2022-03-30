using lab4.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Manager.Departments
{
    public interface InterfaceDManager
    {
        Task<Department> AddDepartment(DRequest request);
        Task<Department> UpdateDepartment(Guid id, DRequest request);
        Task<Department> DeleteDepartment(Guid id);
        Task<Department> GetById(Guid id);
        Task<Department> GetAllUniversity(Guid id);
        Task<List<Department>> GetAllDepartment();
        
    }
}
