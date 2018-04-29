using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ROC.Core
{
    public class MenuHelper
    {

        /// <summary>
        /// 通过反射的方式获取 程序集所有控制器的action 名称
        /// </summary>
        /// <returns></returns>
        public static List<ActionEntity> GetActionsByAssembly()
        {
            var list = new List<ActionEntity>();
            var types = Assembly.Load("ROC.web").GetTypes();
            foreach (var type in types)
            {
                if (type.BaseType.Name.Equals("BaseController"))
                {
                    var members = type.GetMethods();
                    foreach (var m in members)
                    {
                        if (m.ReturnType.Name.Equals("ActionResult"))
                        {
                            string controllerName = m.DeclaringType.Name.Substring(0, m.DeclaringType.Name.Length - 10);  // 去掉“Controller” 后缀

                            if (!list.Any(t => t.Action == m.Name && t.Controller == controllerName))
                            {
                                var item = new ActionEntity();
                                item.Action = m.Name;
                                item.Controller = controllerName;

                                object[] attrs = m.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                                if (attrs.Length > 0)
                                {
                                    item.Description = (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;
                                }                                
                                list.Add(item);
                            }
                        }
                    }
                }
            }

            return list;
        }
        
    }

    /// <summary>
    /// 反射控制器中的 action名称实体
    /// </summary>
    public class ActionEntity
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
