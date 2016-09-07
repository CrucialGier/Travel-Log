using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class PlacesController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(db.Places.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(Places => Places.PlaceId == id);
            @ViewBag.ExperiencesCount = thisPlace.Experiences.Count;
            return View(thisPlace);
        }
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Place Place)
        {
            db.Places.Add(Place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(Places => Places.PlaceId == id);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Name");
            return View(thisPlace);
        }
        [HttpPost]
        public ActionResult Edit(Place Place)
        {
            db.Entry(Place).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(Places => Places.PlaceId == id);
            return View(thisPlace);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(Places => Places.PlaceId == id);
            db.Places.Remove(thisPlace);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}