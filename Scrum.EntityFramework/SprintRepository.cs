using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class SprintRepository : ISprintRepository
    {
        private readonly ScrumDbContext _scrumDbContext = new ScrumDbContext();
        public List<Sprint> All()
        {
            return this._scrumDbContext.Set<Sprint>().ToList();
        }

        public void Delete(Sprint Sprint)
        {
            this._scrumDbContext.Entry(Sprint).State = EntityState.Deleted;
            this._scrumDbContext.SaveChanges();
        }

        public Sprint FindByID(string id)
        {
            return this._scrumDbContext.Set<Sprint>()
                .SingleOrDefault(p => p.ID.ToString().Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public List<Sprint> FindByProject(string projectID)
        {
            return this._scrumDbContext.Set<Sprint>()
                .Where(p => p.ProjectID.ToString().Equals(projectID, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Sprint Save(Sprint Sprint)
        {
            this._scrumDbContext.Set<Sprint>().Add(Sprint);
            this._scrumDbContext.SaveChanges();
            return Sprint;
        }

        public Sprint Update(Sprint dirtySprint)
        {
            this._scrumDbContext.Entry(dirtySprint).State = EntityState.Modified;
            this._scrumDbContext.SaveChanges();
            return dirtySprint;
        }
    }
}
