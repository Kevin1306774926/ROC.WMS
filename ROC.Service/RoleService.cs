using ROC.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC.Service
{
    public class RoleService:AbstractService<Role>,IRoleService
    {
    }

    public interface IRoleService:IService<Role>
    {
    }
}
