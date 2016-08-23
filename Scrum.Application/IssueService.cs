using Scrum.Application.Commands;
using Scrum.Application.Responses;
using Scrum.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IProjectRepository _projectRepository;

        public IssueService(IIssueRepository issueRepository, IProjectRepository projectRepository)
        {
            this._issueRepository = issueRepository;
            this._projectRepository = projectRepository;
        }

        public CreateIssueResponse CreateIssue(CreateIssueCommand createIssue)
        {
            Project project = this._projectRepository.FindByID(createIssue.ProjectID);

            Issue issue = new Issue
            {
                Key = GenerateIssueKey(project, this._issueRepository),
                AssigneeID = createIssue.AssigneeID,
                Attachment = createIssue.Attachment,
                Description = createIssue.Description,
                IssueTypeID = createIssue.IssueTypeID,
                PriorityID = createIssue.PriorityID,
                ProjectID = createIssue.ProjectID,
                ReporterID = createIssue.ReporterID,
                SprintID = createIssue.SprintID,
                Summary = createIssue.Summary
            };

            if (this._issueRepository.FindByKey(issue.Key) == null)
            {
                this._issueRepository.Save(issue);
            }

            return new CreateIssueResponse
            {
                IssueKey = issue.Key
            };
        }

        private string GenerateIssueKey(Project project, IIssueRepository issueRepository)
        {
            int maxValue = issueRepository.FindMaxKey(project.ID.ToString());
            return String.Join("-", project.Key, maxValue);
        }

        public List<Issue> GetAllIssues()
        {
            return this._issueRepository.All();
        }

        public List<IssueType> GetAllIssueTypes()
        {
            return this._issueRepository.AllIssueTypes();
        }

        public List<Priority> GetAllPriorities()
        {
            return this._issueRepository.AllPriorities();
        }
    }
}
