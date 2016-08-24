using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class IssueRepository : IIssueRepository
    {
        private readonly ScrumDbContext _scrumDbContext = new ScrumDbContext();

        public List<Issue> All()
        {
            return this._scrumDbContext.Issues.ToList();
        }

        public void Save(Issue issue)
        {
            this._scrumDbContext.Set<Issue>().Add(issue);
            this._scrumDbContext.SaveChanges();
        }

        public void Update(Issue dirtyissue)
        {
            this._scrumDbContext.Entry(dirtyissue).State = EntityState.Modified;
            this._scrumDbContext.SaveChanges();
        }

        public void Delete(Issue issue)
        {
            this._scrumDbContext.Entry(issue).State = EntityState.Deleted;
            this._scrumDbContext.SaveChanges();
        }

        public Issue FindByKey(string key)
        {
            return this._scrumDbContext.Issues.SingleOrDefault(u => u.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
        }

        public List<Issue> FindByProject(string projectID)
        {
            return this._scrumDbContext.Issues.Where(i => i.ProjectID.Equals(projectID, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public int FindMaxKey(string projectID)
        {
            int maxKey = this._scrumDbContext.Issues
                .Where(i => i.ProjectID.Equals(projectID, StringComparison.OrdinalIgnoreCase))
                .AsEnumerable()
                .Select(i => int.Parse(i.Key.Split('-')[1])).DefaultIfEmpty().Max();
            return maxKey;
        }

        public List<IssueType> AllIssueTypes()
        {
            return this._scrumDbContext.IssueTypes.ToList();
        }

        public List<Priority> AllPriorities()
        {
            return this._scrumDbContext.Priorities.ToList();
        }
    }
}
