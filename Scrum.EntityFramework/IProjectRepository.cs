using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public interface IProjectRepository
    {
        List<Project> All();
        void Delete(Project project);
        void Save(Project project);
        void Update(Project dirtyProject);
        Project FindByKey(String key);
        Project FindByID(String id);
    }
}
