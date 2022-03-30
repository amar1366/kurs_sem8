using lab4.Manager.Universities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class UniversityController : Controller
    {
        private readonly InterfaceUManager _manager;

        public UniversityController(InterfaceUManager manager)
        {
            _manager = manager;
        }
        //представления
        [HttpGet]
        public ActionResult CreateUniversity(Guid UniversityId)
        {
            return View(UniversityId);
        }
        public async Task<ActionResult> UpdateUniversity(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        public async Task<ActionResult> AllProfessor(Guid id)
        {
            var entity = await _manager.GetAllProfessors(id);
            return View(entity);
        }
        [HttpPost]
        //методы, которые будут вызываться на html странице
        public async Task<RedirectToActionResult> Create(Guid DepartmentId, URequest request)
        {
            await _manager.AddUniversity(DepartmentId, request);
            return RedirectToAction("AllUniversity", "Department", new { id = DepartmentId });
        }
        public async Task<RedirectToActionResult> Update(Guid id, URequest request)
        {
            var entity = await _manager.UpdateUniversity(id, request);
            return RedirectToAction("AllUniversity", "Department", new { id = entity.DepartamentId });
        }
        public async Task<RedirectToActionResult> Delete(Guid id, Guid DepartmentId)
        {
            await _manager.DeleteUniversity(id);
            return RedirectToAction("AllUniversity", "Department", new { id = DepartmentId });
        }
        public async Task<ViewResult> SearchProfessor(Guid id, string name, string text)
        {
            var entity = await _manager.Searchprofessor(id, name, text);
            return View("AllProfessor", entity);
        }
    }
}