using System.Collections.Generic;
using Scrum.Application.Commands;
using Scrum.Application.Responses;
using Scrum.EntityFramework;

namespace Scrum.Application
{
    public interface IIssueService
    {
        CreateIssueResponse CreateIssue(CreateIssueCommand createIssue);
        List<Issue> GetAllIssues();
        List<IssueType> GetAllIssueTypes();
        List<Priority> GetAllPriorities();
    }
}