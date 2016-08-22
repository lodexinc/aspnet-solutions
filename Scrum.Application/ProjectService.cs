using Scrum.Application.Commands;
using Scrum.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
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
    }
}
