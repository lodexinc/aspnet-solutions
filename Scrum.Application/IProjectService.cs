using Scrum.Application.Commands;
using Scrum.Application.Reports;
using Scrum.EntityFramework;
using System.Collections.Generic;

namespace Scrum.Application
{
    public interface IProjectService
    {
        void CreateProject(CreateProjectCommand createProject);
        List<Project> GetAllProjects();

        List<User> GetMembers(string projectId);

        ProjectDetailView ViewProjectDetail(string id);
        
    }
}