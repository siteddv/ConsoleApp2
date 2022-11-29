using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Backend.Contexts;
using StudentManager.Backend.Entiries;
using StudentManager.Infrastructure.Managers.Implemetations;
using StudentManager.Infrastructure.Managers.Interfaces;

namespace StudentManager.WebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsManager _studentsManager;

        public StudentsController(IStudentsManager studentsManager)
        {
            _studentsManager = studentsManager;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            List<Student> students = _studentsManager.GetAll();

            if(students == null) 
            { 
                return NotFound(); 
            }

            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Student student = _studentsManager.GetById(id);

            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Id,Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentsManager.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var student = _studentsManager.GetById(id);

            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Age,Id,Name")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                student = _studentsManager.Update(id, student);
                if (student == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Student student = _studentsManager.GetById(id);

            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = _studentsManager.Delete(id);
            if(student == null)
            {
                return Problem("Entity set 'AppDbContext.Students'  is null.");
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
