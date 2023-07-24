using DemoProjectMVC.DbCon;
using DemoProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DemoProjectMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly DemoProjectMVCDbContext _context; //Genererate constructor  by control .

        public StudentController(DemoProjectMVCDbContext context)
        {
            _context = context;
        }

        // Syncronus method 
        //public IActionResult Index()
        //{
        //    var data = _context.Students.ToList();   
        //    return View(data);
        //}

        public async Task <IActionResult> Index()
        {
            var data = await  _context.Students.ToListAsync();    //control . generete framework core
            return View(data);
        }

        public ActionResult Create()

        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student students )
        {

            if (!ModelState.IsValid)
            {
                return View(students);
            }
            _context.Students.Add(students);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public  async  Task <ActionResult> Edit(int id )
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public  async Task<ActionResult> Edit( Student students)
        {
            if(!ModelState.IsValid)
            {
                return View(students);
            }

            _context.Entry(students).State = EntityState.Modified;

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

        public IActionResult Delete(int id)
        {
            return View(_context.Students.Find(id));
        }

        [HttpDelete, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if(student != null)
            {
                _context.Students.Remove(student); 
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }








    }
}
