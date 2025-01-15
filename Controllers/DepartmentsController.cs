using DemoMVC14.Data;
using DemoMVC14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMVC14.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _db;
        public DepartmentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.total = _db.Departments.Where(t => t.IsDeleted == true).Count();
            return View(_db.Departments.Where(v => v.IsDeleted == false).OrderByDescending(x => x.CreationDate));
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            // The IsDeleted = false by default (bool false by default), so no need to add it
            department.IsActive = true;
            _db.Departments.Add(department);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id < 0)
            {
                return RedirectToAction("Index");
            }
            var data = _db.Departments.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            data.IsDeleted = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Restore(int? id)
        {
            var data = _db.Departments.Where(x => x.IsDeleted);
            if (!data.Any() || data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public IActionResult ConfirmRestore(int? id)
        {
            if (id == null || id < 0)
            {
                return RedirectToAction("Index");
            }
            var data = _db.Departments.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            data.IsDeleted = false;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}