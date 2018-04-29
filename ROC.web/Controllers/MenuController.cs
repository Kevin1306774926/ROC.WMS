using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Modles;
using ROC.Service;

namespace ROC.web.Controllers
{
    public class MenuController : BaseController
    {
        IMenuService  service=new MenuService();
        // GET: Menu
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

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(Menu model)
        {
            try
            {
                service.Add(model);
            }
             catch(Exception ex)
            {
                //return View();
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        // POST: Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(Menu model)
        {
            try
            {
                service.Update(model);
            }
            catch(Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        // POST: Menu/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                service.Delete(t => t.Controller == id);                
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;                
            }
            return EasyUIResult();
        }

        [HttpPost]
        public ActionResult InitMenu()
        {
            try
            {
                service.InitMenuByAssembly();
            }
            catch(Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }

            return EasyUIResult();
        }
    }
}
