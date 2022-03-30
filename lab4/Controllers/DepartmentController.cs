using lab4.Manager.Departments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class DepartmentController : Controller
    {
        public readonly InterfaceDManager _manager;

        public DepartmentController(InterfaceDManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        //отвечают за вызов html страницы
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Department(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        public async Task<ActionResult> AllDepartment()
        {
            var entities = await _manager.GetAllDepartment();
            return View(entities);
        }
        public async Task<ViewResult> AllUniversity(Guid id)
        {
            var entity = await _manager.GetAllUniversity(id);
            return View(entity);
        }
        public ViewResult CreateDepartment()
        {
            return View();
        }
        public async Task<ViewResult> UpdateDepartment(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        //методы вызываются с html страницы
        [HttpPost]
        public async Task <ViewResult> Create(DRequest request)
        {
            await _manager.AddDepartment(request);
            var entities = await _manager.GetAllDepartment();
            return View("AllDepartment", entities);
        }
        public async Task<ViewResult> Update(Guid id, DRequest request)
        {
            var entity = await _manager.UpdateDepartment(id, request);
            return View("Department", entity);
        }
        public async Task<ViewResult> Delete(Guid id)
        {
            await _manager.DeleteDepartment(id);
            var entities = await _manager.GetAllDepartment();
            return View("AllDepartment", entities);
        }
    }
}