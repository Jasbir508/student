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
    public class Student_TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Student_TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student_Teacher
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student_Teachers.ToListAsync());
        }

        // GET: Student_Teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Teacher = await _context.Student_Teachers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_Teacher == null)
            {
                return NotFound();
            }

            return View(student_Teacher);
        }

        // GET: Student_Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student_Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Mobile,Address")] Student_Teacher student_Teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student_Teacher);
        }

        // GET: Student_Teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Teacher = await _context.Student_Teachers.FindAsync(id);
            if (student_Teacher == null)
            {
                return NotFound();
            }
            return View(student_Teacher);
        }

        // POST: Student_Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Mobile,Address")] Student_Teacher student_Teacher)
        {
            if (id != student_Teacher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_TeacherExists(student_Teacher.ID))
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
            return View(student_Teacher);
        }

        // GET: Student_Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Teacher = await _context.Student_Teachers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_Teacher == null)
            {
                return NotFound();
            }

            return View(student_Teacher);
        }

        // POST: Student_Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Teacher = await _context.Student_Teachers.FindAsync(id);
            _context.Student_Teachers.Remove(student_Teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_TeacherExists(int id)
        {
            return _context.Student_Teachers.Any(e => e.ID == id);
        }
    }
}
