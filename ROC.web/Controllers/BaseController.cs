using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROC.web.Controllers
{
    public class BaseController:Controller
    {
        public ActionResult Close()
        {
            string sb = @"<script> parent.$('#dialog').dialog('close'); </script>";
            return Content(sb);
        }
    }
}