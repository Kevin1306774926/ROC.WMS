using ROC.Core;
using ROC.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC.BLL
{
    public partial class MenuService
    {
        public void InitMenuByAssembly()
        {
            List<ActionEntity> list = MenuHelper.GetActionsByAssembly();
            foreach (ActionEntity item in list)
            {
                if (this.Get(t => t.Controller.Equals(item.Controller)).Count() < 1)
                {
                    Menu menu = new Menu()
                    {
                        Controller = item.Controller,
                        Url = string.Format("/{0}/{1}", item.Controller, "Index"),
                        OpTime = DateTime.Now
                    };
                    this.Add(menu);
                }
            }
        }
    }
        

    public partial interface IMenuService
    {
        void InitMenuByAssembly();

    }
}
