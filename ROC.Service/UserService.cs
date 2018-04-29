using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROC.Modles;
namespace ROC.Service
{
    public class UserService:AbstractService<User>, IUserService
    {
    }

    public interface IUserService:IService<User>
    {

    }
}
