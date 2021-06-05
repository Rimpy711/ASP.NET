using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CourseRegisteration.Models;
using Microsoft.AspNetCore.Mvc;


namespace CourseRegisteration.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRegistration _reg;
        public StudentController(IRegistration reg)
        {
            _reg = reg;
        }

        public IActionResult Index()
        {
            var model = _reg.GetAllStudents();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _reg.GetStudent(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Students student)
        {
            if (ModelState.IsValid)
            {
                _reg.AddStudent(student);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model = _reg.GetStudent(Id);
            return View(model);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
             _reg.DeleteStudent(Id);
            return RedirectToAction("index");
        }





        [HttpGet]
        public IActionResult Update(int Id)
        {
            var model = _reg.GetStudent(Id);
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(Students studentchanges)
        {
            if (ModelState.IsValid)
            {
                Students updatestudent = _reg.UpdateStudent(studentchanges);

                return RedirectToAction("index");
            }
                return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
         {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
         }
    }

}

