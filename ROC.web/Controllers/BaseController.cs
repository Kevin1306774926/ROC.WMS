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
        protected int Total { get; set; }
        protected object Rows { get; set; }
        protected JsonResult EasyUIResult()
        {
            return Json(new { Success, Message,Data});
        }

        protected object DataGridResult
        {
            get
            {
                return new { total = Total, rows = Rows };
            }
        }
        protected JsonResult EasyUIResult(object data)
        {
            return Json(new { Success, Message, Data = data });
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

    }

}