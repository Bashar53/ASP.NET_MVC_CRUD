using DemoProjectMVC.DbCon;
using DemoProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectMVC.Controllers
{
    public class OfficerController : Controller
    {
        private readonly DemoProjectMVCDbContext _context;
        public OfficerController(DemoProjectMVCDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data =  await _context.Officers.ToListAsync();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Officer officers)
        {


            if (!ModelState.IsValid)
            {
                return View(officers);
            }
            _context.Officers.Add(officers);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Edit(int id)
        {
            var officer_edit = await _context.Officers.FindAsync(id);
            return View(officer_edit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Officer officers)
        {
            if (!ModelState.IsValid)
            {
                return View(officers);
            }

            _context.Entry(officers).State = EntityState.Modified;

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

        public async Task<ActionResult> Details(int id)
        {

            var officer_details = await _context.Officers.FindAsync(id);
            return View(officer_details);
        }



    }
}
