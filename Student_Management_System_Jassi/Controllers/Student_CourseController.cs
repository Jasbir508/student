using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_Jassi.Data;
using Student_Management_System_Jassi.Models;

namespace Student_Management_System_Jassi.Controllers
{
    [Authorize]
    public class Student_CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Student_CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student_Course
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student_Courses.ToListAsync());
        }

        // GET: Student_Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_Course == null)
            {
                return NotFound();
            }

            return View(student_Course);
        }

        // GET: Student_Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student_Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Course_Name")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student_Course);
        }

        // GET: Student_Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Courses.FindAsync(id);
            if (student_Course == null)
            {
                return NotFound();
            }
            return View(student_Course);
        }

        // POST: Student_Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Course_Name")] Student_Course student_Course)
        {
            if (id != student_Course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_CourseExists(student_Course.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student_Course);
        }

        // GET: Student_Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Course = await _context.Student_Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_Course == null)
            {
                return NotFound();
            }

            return View(student_Course);
        }

        // POST: Student_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Course = await _context.Student_Courses.FindAsync(id);
            _context.Student_Courses.Remove(student_Course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_CourseExists(int id)
        {
            return _context.Student_Courses.Any(e => e.ID == id);
        }
    }
}
