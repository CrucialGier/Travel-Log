using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class PersonsController : Controller
    {
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            return View(db.Persons.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(Persons => Persons.PersonId == id);
            return View(thisPerson);
        }
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person Person)
        {
            db.Persons.Add(Person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(Persons => Persons.PersonId == id);
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "Name");
            return View(thisPerson);
        }
        [HttpPost]
        public ActionResult Edit(Person Person)
        {
            db.Entry(Person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(Persons => Persons.PersonId == id);
            return View(thisPerson);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisPerson = db.Persons.FirstOrDefault(Persons => Persons.PersonId == id);
            db.Persons.Remove(thisPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}