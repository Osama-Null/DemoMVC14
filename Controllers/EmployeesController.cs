using DemoMVC14.Data;
using DemoMVC14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMVC14.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _db;
        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Employees);
        }
        public IActionResult Add()
        {
            ViewBag.Depts = new SelectList(_db.Departments.Where(x => x.IsActive && x.IsDeleted == false), "DepartmentId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
