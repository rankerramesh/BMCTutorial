using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMCTutorial.Models;

namespace BMCTutorial.Controllers
{
    public class PersonController : Controller
    {
        public PersonController()
        {

        }

        public IActionResult Index()
        {
            List<PersonModel> people = BusinessService.people;
            return View(people);
        }
        public IActionResult Create()
        {
            PersonModel person = new PersonModel();
            return View(person);
        }
        [HttpPost]
        public IActionResult Create(PersonModel person)
        {
            List<PersonModel> people = BusinessService.people;
            people.Add(person);
            return RedirectToAction("Index");
        }
        public IActionResult EditPerson(int id)
        {
            List<PersonModel> people = BusinessService.people;
            PersonModel person = people.Where(x => x.ID == id).FirstOrDefault();
            return View(person);
        }
        [HttpPost]
        public IActionResult EditPerson(PersonModel person)
        {
            List<PersonModel> people = BusinessService.people;
            PersonModel p = people.Where(x => x.ID == person.ID).FirstOrDefault();
            p.Name = person.Name;
            p.Address = person.Address;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            List<PersonModel> people = BusinessService.people;
            PersonModel p = people.Where(x => x.ID == id).FirstOrDefault();
            people.Remove(p);
            return RedirectToAction("Index");


        }
    }
}
