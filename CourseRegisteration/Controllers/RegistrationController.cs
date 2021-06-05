using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegisteration.Models;
using CourseRegisteration.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseRegisteration.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IRegistration _reg;
        private readonly AppDbContext _con;

        public RegistrationController(IRegistration reg, AppDbContext context)
        {
            _reg = reg;
            _con = context;
        }

        public IActionResult Index()
        {
            var model = _reg.test();
            return View(model);
        }
        [HttpGet]

        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_con.Courses, "CourseId", "CourseId");
            ViewData["InstructorId"] = new SelectList(_con.Instructors, "InstructorId", "InstructorId");
            ViewData["StudentId"] = new SelectList(_con.Students, "StudentId", "StudentId");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _reg.AddNewRegistration(registration);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _con.Registration
                .Include(r => r.course)
                .Include(r => r.instructor)
                .Include(r => r.student)
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _con.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_con.Courses, "CourseId", "CourseName", registration.CourseId);
            ViewData["InstructorId"] = new SelectList(_con.Instructors, "InstructorId", "FirstName", registration.InstructorId);
            ViewData["StudentId"] = new SelectList(_con.Students, "StudentId", "FirstName", registration.StudentId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("RegistrationId,Type,StudentId,CourseId,InstructorId")] Registration registration)
        {
            if (id != registration.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _con.Update(registration);
                    await _con.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.RegistrationId))
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
            ViewData["CourseId"] = new SelectList(_con.Courses, "CourseName", "CourseName");

            ViewData["InstructorId"] = new SelectList(_con.Instructors, "InstructorId", "Course", registration.InstructorId);
            ViewData["StudentId"] = new SelectList(_con.Students, "StudentId", "Email", registration.StudentId);
            return View(registration);
        }

        private bool RegistrationExists(int id)
        {
            return _con.Registration.Any(e => e.RegistrationId == id);
        }



        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _con.Registration.FindAsync(id);
            _con.Registration.Remove(registration);
            await _con.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
