using System.Collections.Generic;

namespace Scrum.EntityFramework
{
    public interface ISprintRepository
    {
        List<Sprint> All();
        void Delete(Sprint Sprint);
        Sprint FindByID(string id);
        List<Sprint> FindByProject(string projectID);
        Sprint Save(Sprint Sprint);
        Sprint Update(Sprint dirtySprint);
    }
}