using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ExperiencesController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(db.Experiences.Include(Experiences => Experiences.Place).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(thisExperience);
        }
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Experience Experience)
        {
            db.Experiences.Add(Experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Name");
            return View(thisExperience);
        }
        [HttpPost]
        public ActionResult Edit(Experience Experience)
        {
            db.Entry(Experience).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            return View(thisExperience);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(Experiences => Experiences.ExperienceId == id);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}