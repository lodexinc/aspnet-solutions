using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ScrumDbContext _scrumDbContext = new ScrumDbContext();
        public List<Project> All()
        {
            return this._scrumDbContext.Set<Project>().ToList();
        }

        public void Delete(Project project)
        {
            this._scrumDbContext.Entry(project).State = EntityState.Deleted;
            this._scrumDbContext.SaveChanges();
        }

        public Project FindByID(string id)
        {
            return this._scrumDbContext.Set<Project>()
                .SingleOrDefault(p => p.ID.ToString().Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public Project FindByKey(string key)
        {
            return this._scrumDbContext.Set<Project>()
                .SingleOrDefault(p => p.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
        }

        public void Save(Project project)
        {
            this._scrumDbContext.Set<Project>().Add(project);
            this._scrumDbContext.SaveChanges();
        }

        public void Update(Project dirtyProject)
        {
            this._scrumDbContext.Entry(dirtyProject).State = EntityState.Modified;
            this._scrumDbContext.SaveChanges();
        }
    }
}
