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
    public class Student_AdmissionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Student_AdmissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student_Admission
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student_Admissions.ToListAsync());
        }

        // GET: Student_Admission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Admission = await _context.Student_Admissions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_Admission == null)
            {
                return NotFound();
            }

            return View(student_Admission);
        }

        // GET: Student_Admission/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student_Admission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Mobile,Address")] Student_Admission student_Admission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student_Admission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student_Admission);
        }

        // GET: Student_Admission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Admission = await _context.Student_Admissions.FindAsync(id);
            if (student_Admission == null)
            {
                return NotFound();
            }
            return View(student_Admission);
        }

        // POST: Student_Admission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Mobile,Address")] Student_Admission student_Admission)
        {
            if (id != student_Admission.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_Admission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_AdmissionExists(student_Admission.ID))
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
            return View(student_Admission);
        }

        // GET: Student_Admission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_Admission = await _context.Student_Admissions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student_Admission == null)
            {
                return NotFound();
            }

            return View(student_Admission);
        }

        // POST: Student_Admission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_Admission = await _context.Student_Admissions.FindAsync(id);
            _context.Student_Admissions.Remove(student_Admission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_AdmissionExists(int id)
        {
            return _context.Student_Admissions.Any(e => e.ID == id);
        }
    }
}
