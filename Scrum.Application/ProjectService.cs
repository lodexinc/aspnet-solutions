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
        private readonly IUserRepository _userRepository;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            this._projectRepository = projectRepository;
            this._userRepository = userRepository;
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
    }
}
