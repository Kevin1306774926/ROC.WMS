using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROC.web.Controllers
{
    public class BaseController:Controller
    {
        protected bool Success { get; set; }
        protected string Message { get; set; }
        protected object Data { get; set;}
        protected int Total=0;
        protected object Rows { get; set; }

        protected int PageIndex { get; set; }
        protected int PageSize { get; set; }
        protected string SortName { get; set; }
        protected bool IsAsc { get; set; }

        protected object DataGridData
        {
            get
            {
                return new { total = Total, rows = Rows };
            }
        }

        protected JsonResult EasyUIResult()
        {
            return Json(new { Success, Message,Data});
        }
        protected JsonResult EasyUIResult(object data)
        {
            return Json(new { Success, Message, Data = data },JsonRequestBehavior.AllowGet);
        }
        protected JsonResult DataGridResult()
        {
            return Json(new { total = Total, rows = Rows }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Close()
        {
            string sb = @"<script> parent.$('#dialog').dialog('close'); </script>";
            return Content(sb);
        }

        public BaseController()
        {
            Success = true;
            Message = string.Empty;

                     
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            this.PageSize = Request["rows"] == null ? 1 : int.Parse(Request["rows"]);
            this.SortName = Request["sort"];
            string sortOrder = Request["order"];
            this.IsAsc = sortOrder == null ? true : sortOrder.ToUpper().Equals("ASC");   
            
            base.OnActionExecuting(filterContext);
        }

    }

}