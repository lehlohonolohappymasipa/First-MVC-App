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
        public StudentController(MyAppContext db)
        {
            _db = db;
        }

        //Code to get the list of students from the database and display it in the view
        public async Task<IActionResult> Index()
        {
            var student = await _db.Students.ToListAsync();
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
            var student = await _db.Students.FindAsync(id);
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
    }
}
