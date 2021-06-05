using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CourseRegisteration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegisteration.Controllers
{
    public class CourseController : Controller
    {

        private readonly IRegistration _reg;
        public CourseController(IRegistration reg)
        {
            _reg = reg;
        }

        public IActionResult Index()
        {
            var model = _reg.GetAllCourse();
            return View(model);
        }
         
      
        public IActionResult StudentList(int id)
        {
            var model = _reg.StudentListById(id);
            return View(model);

        }

        public IActionResult Details(int id)
        {
            var model = _reg.GetCourse(id);
            return View(model);
        }
    

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Courses course)
        {
            if (ModelState.IsValid)
            {
                 _reg.AddCourse(course);
                return RedirectToAction("index");
               // return RedirectToAction("Details", "course",new { CourseId = newcourse.CourseId });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model=_reg.GetCourse(Id);
            return View(model);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
             _reg.DeleteCourse(Id);
            return RedirectToAction("index");


        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var model= _reg.GetCourse(Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Courses coursechanges)
        {
            if (ModelState.IsValid)
            {
                Courses updatecourse = _reg.UpdateCourse(coursechanges);

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
