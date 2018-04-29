using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROC.Core;
using ROC.Modles;

namespace ROC.BLL
{
    public partial interface IActionInfoService
    {
        void InitActionsByAssembly();        
    }
    public partial class ActionInfoService
    {
        /// <summary>
        /// 初始化系统中的所有控制器中的Action 名称 为菜单
        /// </summary>
        public void InitActionsByAssembly()
        {
            List<ActionEntity> list = MenuHelper.GetActionsByAssembly();
            List<ActionInfo> actions = new List<ActionInfo>();
            foreach(var item in list)
            {
                ActionInfo a = new ActionInfo();
                a.Action = item.Action;
                a.Controller = item.Controller;
                a.ActionName = item.ActionName;
                a.ControllerName = item.ControllerName;
                a.Description = item.Description;
                a.OpTime = DateTime.Now;
                actions.Add(a);
            }

            this.Delete(t => true);
            this.Add(actions.ToArray());
        }

    }
}
