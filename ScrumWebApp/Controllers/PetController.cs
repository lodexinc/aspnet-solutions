using Scrum.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWebApp.Controllers
{
    public class PetController : BaseController
    {
        // GET: Pet
        public ActionResult Index()
        {
            Pet pet = new Pet() { Name = "Chu cho tham tu" };
            return View(pet);
        }

        [HttpPost]
        public ActionResult CreatePet(Pet pet)
        {
            DateTime now = DateTime.Now;
            pet.CreatedDate = String.Join(" - ", now.ToLongDateString(), now.ToLongTimeString());
            return Json(pet);
        }
    }
}