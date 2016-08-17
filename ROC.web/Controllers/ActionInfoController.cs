using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.BLL;
using ROC.Modles;

namespace ROC.web.Controllers
{
    public class ActionInfoController : BaseController
    {
        IActionInfoService service = new ActionInfoService();
        // GET: ActionInfo
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

        /// <summary>
        /// 初始化系统中的所有控制器中的Action 名称
        /// </summary>
        /// <returns></returns>
        public ActionResult InitActions()
        {
            try
            {
                service.InitActionsByAssembly();
                return Json(new { Message = "", Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message, Success = false });
            }
        }
        // GET: ActionInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActionInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionInfo/Create
        [HttpPost]
        public ActionResult Create(ActionInfo model)
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

        // GET: ActionInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.Get(id);
            return View(model);
        }

        // POST: ActionInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ActionInfo model)
        {
            try
            {
                // TODO: Add update logic here
                service.Update(model);
                return RedirectToAction("Close");
            }
            catch
            {
                return View();
            }
        }

        // GET: ActionInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActionInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.Delete(t=>t.Id==id);
                return Json(new { Message = "",Success=true });
            }
            catch(Exception ex)
            {
                return Json(new { Message =ex.Message, Success=false });
            }
        }
    }
}
