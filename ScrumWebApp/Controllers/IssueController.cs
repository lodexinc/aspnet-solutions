using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWebApp.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        public ActionResult CreateIssue()
        {
            System.Threading.Thread.Sleep(2000);
            return PartialView("_CreateIssue");
        }
    }
}