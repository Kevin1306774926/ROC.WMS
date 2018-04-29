using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Modles;
using ROC.Service;

namespace ROC.web.Controllers
{
    public class MenuClassController : BaseController
    {
        IMenuClassService service = new MenuClassService();

        /// <summary>
        /// 获取菜单树的数据Json格式
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuTree()
        {
            var menuTree = service.GetMenuTree();
            return Json(menuTree, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuClassTree()
        {
            var menuTree = service.GetMenuClassTree();
            return Json(menuTree, JsonRequestBehavior.AllowGet);
        }

        // GET: MenuClass
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 1 : int.Parse(Request["rows"]);
            string sortName = Request["sort"];
            string sortOrder = Request["order"];
            bool IsAsc = sortOrder == null ? true : sortOrder.ToUpper().Equals("ASC");
            int total = 0;

            var data = service.Get(t => true, sortName, pageSize, pageIndex, out total, IsAsc);
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }        

        // POST: MenuClass/Create
        [HttpPost]
        public ActionResult Create(MenuClass model)
        {
            try
            {
                service.Add(model);
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        // POST: MenuClass/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MenuClass model)
        {
            try
            {
                service.Update(model);
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        // POST: MenuClass/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.Delete(t => t.Id == id);
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }
    }
}
