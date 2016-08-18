using Ebox.MvcIntegratedAngularJs.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebox.MvcIntegratedAngularJs.Repositories
{
    public interface IAccountRepository
    {
        List<User> Users();
        User FindByEmail(String email);
    }
}
