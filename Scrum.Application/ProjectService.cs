using Scrum.Application.Commands;
using Scrum.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Application.Reports;

namespace Scrum.Application
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIssueRepository _issueRepository;
        private readonly ISprintRepository _sprintRepository;

        public ProjectService(IProjectRepository projectRepository,
            IUserRepository userRepository,
            IIssueRepository issueRepository,
            ISprintRepository sprintRepository)
        {
            this._projectRepository = projectRepository;
            this._userRepository = userRepository;
            this._issueRepository = issueRepository;
            this._sprintRepository = sprintRepository;
        }

        public void CreateProject(CreateProjectCommand createProject)
        {
            Project project = new Project
            {
                Key = createProject.Key,
                Name = createProject.Name
            };

            if (this._projectRepository.FindByKey(project.Key) == null)
            {
                this._projectRepository.Save(project);
            }
        }

        public List<Project> GetAllProjects()
        {
            return this._projectRepository.All();
        }

        public List<User> GetMembers(string projectId)
        {
            return this._userRepository.All();
        }

        public ProjectDetailView ViewProjectDetail(string id)
        {
            Project project = this._projectRepository.FindByID(id);
            List<Issue> issueOfProjects = this._issueRepository.FindByProject(id);
            List<IssueType> issueTypes = this._issueRepository.AllIssueTypes();
            List<IssueStatistics> statistics = new List<IssueStatistics>();
            issueTypes.ForEach(it =>
            {
                var issueOfThisType = issueOfProjects.Where(i => i.IssueTypeID.Equals(it.ID, StringComparison.OrdinalIgnoreCase)).ToList();
                if (issueOfThisType.Any())
                {
                    statistics.Add(new IssueStatistics
                    {
                        Type = it,
                        Numbers = issueOfThisType.Count
                    });
                }
            });

            return new ProjectDetailView
            {
                ProjectID = project.ID.ToString(),
                ProjectKey = project.Key,
                ProjectName = project.Name,
                IssueStatistics = statistics
            };
        }

        public Sprint CreateSprint(CreateSprintCommand command)
        {
            Sprint sprint = new Sprint
            {
                ProjectID = Guid.Parse(command.ProjectID),
                Name = command.Name,
                Goal = command.Goal
            };

            return this._sprintRepository.Save(sprint);
        }

        public List<Sprint> SprintsOfProject(string project)
        {
            return this._sprintRepository.FindByProject(project);
        }
    }
}
