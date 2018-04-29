using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Modles;
using ROC.Service;
using System.Data.SqlClient;

namespace ROC.web.Controllers
{
    public class RoleController : BaseController
    {
        IRoleService  service=new RoleService();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRolePermission(Guid roleId)
        {
            try
            {
                if (roleId!=null)
                {
                    IRoleActionInfoService tmp = new RoleActionInfoService();                    
                    var list = tmp.Get(t => t.RoleId == roleId, "ActionInfo").ToList();
                    var model = from item in list
                                select new
                                {
                                    RoleId = roleId,
                                    Id = item.Id,
                                    ActionId=item.ActionId,
                                    IsUsed = item.IsUsed,
                                    ControllerName = item.ActionInfo.ControllerName,
                                    ActionName = item.ActionInfo.ActionName,
                                    Description = item.ActionInfo.Description
                                };
                    Total =model.ToList().Count();
                    Rows = model;
                    Data = DataGridResult;
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

            //var data = service.Get(t => true, sortName, pageSize, pageIndex, out total, IsAsc);
            var data = service.Get(t => true).ToList();
            total = data.Count();
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }        

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Role model)
        {
            try
            {
                model.OpTime = DateTime.Now;
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

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(Role model)
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

        // POST: Role/Delete/5
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

        public ActionResult InitRolePermission(string roleId)
        {
            try
            {
                if (!string.IsNullOrEmpty(roleId))
                {
                    service.ExecuteSqlCommand("exec InitRolePermission @RoleId", new SqlParameter("@RoleId", roleId));
                }
            }
            catch (Exception ex)
            {
                Success = false;
                Message = ex.Message;
            }
            return EasyUIResult();
        }

        public ActionResult UpdateRolePermission()
        {
            try
            {
                string roleId = Request["roleId"];
                string actionIds = Request["id"];
                service.ExecuteSqlCommand("exec [UploadRolePermission] @RoleId,@Ids", new SqlParameter("RoleId",roleId), new SqlParameter("Ids", actionIds));
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
