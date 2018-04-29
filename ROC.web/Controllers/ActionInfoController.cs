using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Modles;
using ROC.Service;
using System.Web.Script.Serialization;

namespace ROC.web.Controllers
{
    public class ActionInfoController : BaseController
    {
        IActionInfoService  service=new ActionInfoService();
        // GET: ActionInfo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Get()
        {
            try
            {
                string controller = Request["Id"];
                if (!string.IsNullOrEmpty(controller))
                {
                    var data = service.Get(t => t.Controller == controller).OrderBy(t => t.Action).ToList();
                    this.Total = data.Count();
                    this.Rows = data;
                    this.Data = DataGridResult;
                }
            }
            catch(Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
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
        public ActionResult InitActions()
        {
            try
            {
                service.InitActionsByAssembly();
                
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        // POST: ActionInfo/Create
        [HttpPost]
        public ActionResult Create(ActionInfo model)
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

        // POST: ActionInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(ActionInfo model)
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

        // POST: ActionInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                service.Delete(t => t.Id== id);                
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;                
            }
            return EasyUIResult();
        }

        [HttpPost]
        public ActionResult AcceptChange()
        {
            string msg = string.Empty;
            try
            {
                string update = Request["update"];
                if(string.IsNullOrEmpty(update))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<ActionInfo> list = js.Deserialize<List<ActionInfo>>(update);
                    service.Update(list.ToArray());
                }
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
