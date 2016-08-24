using Scrum.Application;
using Scrum.Application.Commands;
using ScrumWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWebApp.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            this._projectService = projectService;
        }

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            return PartialView("_CreateProject");
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectCommand createProjectCommand)
        {
            this._projectService.CreateProject(createProjectCommand);
            return View();
        }


        public ActionResult ViewProjects()
        {
            return View();
        }


        public JsonResult SearchProject(String q)
        {
            var projects = this._projectService.GetAllProjects();
            if (!String.IsNullOrEmpty(q))
            {
                projects = projects.Where(p => p.Name.ToLower().Contains(q.ToLower())).OrderBy(p => p.Key).ToList();
            }

            return Json(projects.Select(p => new SelectListItemModel { Name = p.Name, Value = p.ID.ToString() }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMembers(String q)
        {
            var projects = this._projectService.GetMembers(q);
            return Json(projects.Select(p => new SelectListItemModel
            {
                Name = String.Join(" ", p.FirsName, p.LastName),
                Value = p.Email
            }), JsonRequestBehavior.AllowGet);
        }
    }
}