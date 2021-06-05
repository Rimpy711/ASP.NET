using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CourseRegisteration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegisteration.Controllers
{
    public class InstructorController : Controller
    {

            private readonly IRegistration _reg;
            public InstructorController(IRegistration reg)
            {
                _reg = reg;
            }

            public IActionResult Index()
            {
                var model = _reg.GetAllInstructors();
                return View(model);
            }

           public IActionResult Details(int id)
           {    
              var model = _reg.GetInstructor(id);
              return View(model);
           }

           [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Instructors instructor)
            {
                if (ModelState.IsValid)
                {
                    _reg.AddInstructor(instructor);
                    return RedirectToAction("index");
 
                }
                    return View();
            }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var model = _reg.GetInstructor(Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Instructors instructorchanges)
        {
            if (ModelState.IsValid)
            {
                Instructors updatechanges = _reg.UpdateInstructor(instructorchanges);
                return RedirectToAction("index");


            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model = _reg.GetInstructor(Id);
            return View(model);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            _reg.DeleteInstructor(Id);
            return RedirectToAction("index");


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
