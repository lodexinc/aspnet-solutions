using System.Collections.Generic;

namespace Scrum.EntityFramework
{
    public interface IIssueRepository
    {
        List<Issue> All();
        List<IssueType> AllIssueTypes();
        List<Priority> AllPriorities();
        void Delete(Issue issue);
        Issue FindByKey(string key);
        List<Issue> FindByProject(string projectID);
        int FindMaxKey(string projectID);
        void Save(Issue issue);
        void Update(Issue dirtyissue);
    }
}