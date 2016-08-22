using Scrum.Application.Commands;

namespace Scrum.Application
{
    public interface IProjectService
    {
        void CreateProject(CreateProjectCommand createProject);
    }
}