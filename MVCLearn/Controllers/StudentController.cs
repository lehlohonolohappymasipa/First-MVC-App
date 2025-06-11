using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLearn.Data;
using MVCLearn.Models;

namespace MVCLearn.Controllers
{
    public class StudentController : Controller
    {
        //Code to access the database
        private readonly MyAppContext _db;
        private DbSet<Student> Students => _db.Students;
        public StudentController(MyAppContext db)
        {
            _db = db;
        }

        //Code to get the list of students from the database and display it in the view
        public async Task<IActionResult> Index()
        {
            var student = await Students.ToListAsync();
            return View(student);
        }

        //CRUD Operations
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, StudentNo, Name, Course, Year, Institution")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Add(student);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await Students.FirstOrDefaultAsync(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, StudentNo, Name, Course, Year, Institution")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Update(student);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var student = await Students.FindAsync(id);
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await Students.FindAsync(id);
            if (student != null)
            {
                Students.Remove(student);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
