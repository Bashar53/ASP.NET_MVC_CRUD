using DemoProjectMVC.DbCon;
using DemoProjectMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace DemoProjectMVC.Controllers
{
  
    public class TeacherController : Controller
    {
        private readonly DemoProjectMVCDbContext _context;

        public TeacherController(DemoProjectMVCDbContext context)
        {
            _context = context;
        }

        //GET: TeacherController
          public async Task<IActionResult> Index()
        {
            var data = await _context.Teachers.ToListAsync();    //control . generete framework core
            return View(data);
        }


        // GET: TeacherController/Details/5

        public async Task<ActionResult> Details(int id)
        {

            var teacher_details = await _context.Teachers.FindAsync(id);
            return View(teacher_details);
        }


        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]


        //[ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teachers)
        {


            if (!ModelState.IsValid)
            {
                return View(teachers);
            }
            _context.Teachers.Add(teachers);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        // GET: TeacherController/Edit/5
        public  async Task<ActionResult> Edit(int id)
        {
            var teacher_edit = await _context.Teachers.FindAsync(id); 
            return View(teacher_edit);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Teacher teachers)
        {
            if (!ModelState.IsValid)
            {
                return View(teachers);
            }

            _context.Entry(teachers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }


        }
        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeacherController/Delete/5
      //  [HttpPost]
        //  [ValidateAntiForgeryToken]

        



    }
}
