using ROC.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC.Service
{
    public class RoleActionInfoService : AbstractService<RoleActionInfo>, IRoleActionInfoService
    {
    }

    public interface IRoleActionInfoService : IService<RoleActionInfo>
    { }
}
