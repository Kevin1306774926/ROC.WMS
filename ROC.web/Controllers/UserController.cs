﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Service;
using ROC.Modles;

namespace ROC.web.Controllers
{
    public class UserController : BaseController
    {

        IUserService service = new UserService();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            //int pageSize = Request["rows"] == null ? 1 : int.Parse(Request["rows"]);
            //string sortName = Request["sort"];
            //string sortOrder = Request["order"];
            //bool IsAsc = sortOrder == null ? true : sortOrder.ToUpper().Equals("ASC");
            //int total = 0;

            this.Rows = service.Get(t => true, this.SortName, PageSize, PageIndex, out Total, IsAsc);
            //var result = new { total = total, rows = data };
            //return Json(result, JsonRequestBehavior.AllowGet);
            return DataGridResult();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User model)
        {
            try
            {
                // TODO: Add insert logic here
                service.Add(model);
                //return RedirectToAction("Close");                
            }
            catch(Exception ex)
            {
                //return View();
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User model)
        {
            try
            {
                service.Update(model);

                //return RedirectToAction("Close");
            }
            catch(Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }

            return EasyUIResult();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                service.Delete(t => t.Id.ToString() == id);                
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