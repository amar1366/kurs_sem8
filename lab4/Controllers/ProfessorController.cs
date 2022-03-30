using lab4.Manager.Professors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly InterfacePManager _manager;

        public ProfessorController(InterfacePManager manager)
        {
            _manager = manager;
        }
        //представления
        [HttpGet]
        public ActionResult CreateProfessor(Guid UniversitytId)
        {
            return View(UniversitytId);
        }
        public async Task<ActionResult> UpdateProfessor(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        //методы, которые будут вызываться на html странице
        [HttpPost]
        public async Task<RedirectToActionResult> Create(Guid UniversityId, PRequest request)
        {
            var entity = await _manager.AddProfessor(UniversityId, request);
            return RedirectToAction("AllProfessor", "University", new { id = entity.UniversityId });
        }
        public async Task<RedirectToActionResult> Update(Guid id, PRequest request)
        {
            var entity = await _manager.UpdateProfessor(id, request);
            return RedirectToAction("AllProfessor", "University", new { id = entity.UniversityId });
        }
        public async Task<RedirectToActionResult> Delete(Guid id)
        {
            var UniversityId = await _manager.DeleteProfessor(id);
            return RedirectToAction("AllProfessor", "University", new { id = UniversityId });
        }

    }
}