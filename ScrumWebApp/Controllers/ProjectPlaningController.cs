using Scrum.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWebApp.Controllers
{
    [Authorize]
    public class ProjectPlaningController : BaseController
    {
        private readonly IProjectService _projectService;
        public ProjectPlaningController(IProjectService projectService)
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
    }
}