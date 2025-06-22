using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLearn.Data;
using MVCLearn.Models;

namespace MVCLearn.Controllers
{
    public class LeaderController : Controller
    {
        private readonly MyAppContext _context;
        public LeaderController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var leader = await _context.Leader.ToListAsync();
            return View(leader);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id, [Bind("Id, Name, IsVisionary, HasIntegrity, HasHumility, IsResilient, IsDecisive, IsLeader")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leader);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(leader);
        }
    }
}
