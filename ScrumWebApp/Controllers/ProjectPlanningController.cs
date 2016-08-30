using Scrum.Application;
using Scrum.Application.Commands;
using Scrum.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWebApp.Controllers
{
    [Authorize]
    public class ProjectPlanningController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectPlanningController(IProjectService projectService)
        {
            this._projectService = projectService;
        }
        public ActionResult ViewDetail(String project)
        {
            var projectDetailView = this._projectService.ViewProjectDetail(project);
            if(this.Request.IsAjaxRequest())
            {
                return Json(projectDetailView, JsonRequestBehavior.AllowGet);
            }

            return View(projectDetailView);
        }

        public ActionResult CreateSprint(String project)
        {
            CreateSprintCommand empty = new CreateSprintCommand
            {
                ProjectID = project
            };
            return PartialView("_CreateSprint", empty);
        }

        [HttpPost]
        public ActionResult CreateSprint(CreateSprintCommand command)
        {
            Sprint response = this._projectService.CreateSprint(command);
            return Json(response);
        }

        public ActionResult SprintOfProject(string project)
        {
            return Json(this._projectService.SprintsOfProject(project), JsonRequestBehavior.AllowGet);
        }
    }
}