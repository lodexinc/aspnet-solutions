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
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            this._issueService = issueService;
        }
        // GET: Issue
        public ActionResult CreateIssue()
        {
            System.Threading.Thread.Sleep(2000);
            return PartialView("_CreateIssue");
        }

        [HttpPost]
        public ActionResult CreateIssue(CreateIssueCommand command)
        {
            System.Threading.Thread.Sleep(2000);
            var response = this._issueService.CreateIssue(command);
            return Json(response);
        }

        public ActionResult IssueTypes()
        {
            System.Threading.Thread.Sleep(2000);
            var response = this._issueService.GetAllIssueTypes();
            return Json(response.Select(p => new SelectListItemModel { Name = p.Name, Value = p.ID.ToString() }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Priorities()
        {
            System.Threading.Thread.Sleep(2000);
            var response = this._issueService.GetAllPriorities();
            return Json(response.Select(p => new SelectListItemModel { Name = p.Name, Value = p.ID.ToString() }), JsonRequestBehavior.AllowGet);
        }
    }
}