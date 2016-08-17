using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Modles;
using ROC.BLL;

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


        // GET: MenuClass/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuClass/Create
        [HttpPost]
        public ActionResult Create(MenuClass model)
        {
            try
            {
                // TODO: Add insert logic here
                service.Add(model);
                return RedirectToAction("Close");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuClass/Edit/5
        public ActionResult Edit(string id)
        {
            var model = service.Get(id);
            return View(model);
        }

        // POST: MenuClass/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MenuClass model)
        {
            try
            {
                service.Update(model);

                return RedirectToAction("Close");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuClass/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuClass/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                service.Delete(t => t.Code == id);
                return Json(new { Message = "", Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message, Success = false });
            }
        }
    }
}
