using Scrum.Application.Commands;
using Scrum.EntityFramework;
using System.Collections.Generic;

namespace Scrum.Application
{
    public interface IProjectService
    {
        void CreateProject(CreateProjectCommand createProject);
        List<Project> getAllProjects();
    }
}