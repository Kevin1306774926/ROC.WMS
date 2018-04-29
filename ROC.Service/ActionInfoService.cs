using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROC.Core;
using ROC.Modles;

namespace ROC.Service
{
    public partial interface IActionInfoService:IService<ActionInfo>
    {
        void InitActionsByAssembly();        
    }
    public partial class ActionInfoService:AbstractService<ActionInfo>,IActionInfoService
    {
        /// <summary>
        /// 初始化系统中的所有控制器中的Action 名称 为菜单
        /// </summary>
        public void InitActionsByAssembly()
        {
            List<ActionEntity> list = MenuHelper.GetActionsByAssembly();
            List<ActionInfo> actions = this.Get(t => true).ToList();
            List<ActionInfo> tmp = new List<ActionInfo>();
            foreach(var item in list)
            {
                if (!actions.Any(t => t.Controller == item.Controller && t.Action == item.Action))
                {
                    ActionInfo a = new ActionInfo();
                    a.Action = item.Action;
                    a.Controller = item.Controller;
                    a.ActionName = item.ActionName;
                    //a.ControllerName = item.ControllerName;
                    a.Description = item.Description;
                    a.OpTime = DateTime.Now;
                    tmp.Add(a);
                }
            }            
            this.Add(tmp.ToArray());
        }

    }
}
