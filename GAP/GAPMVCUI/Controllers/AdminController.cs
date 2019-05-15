using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using GAPMVCUI.Models;

namespace GAPMVCUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (TempData.Peek("Usertype")== null || TempData.Peek("UserType").ToString() != "Admin")
            {
                filterContext.Result = new RedirectResult("/Accounts/Logout");
            }
        }

        // GET: Admin
        public ActionResult PendingComplaints()
        {
            var Repository = new ComplaintsRepository();
            var ObjComplaints = Repository.ViewPendingComplaints();

            List<ComplaintViewModel> ObjModel = new List<ComplaintViewModel>();
            foreach(var item in ObjComplaints)
            {
                ObjModel.Add(new ComplaintViewModel { Id = item.Id, Category_Of_Crime = item.Category_Of_Crime, Suspect_Name = item.Suspect_Name});
            }
            return View(ObjModel);
        }

        public ActionResult ViewComplaint(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(400);

            var Repository = new ComplaintsRepository();
            var ObjComplaint = Repository.ViewComplaintById(id.Value);

            if (ObjComplaint == null) return HttpNotFound();
            var ObjViewModel = new ComplaintViewModel()
            {
                Id = ObjComplaint.Id,
                Category_Of_Crime = ObjComplaint.Category_Of_Crime,
                Suspect_Name = ObjComplaint.Suspect_Name,
                Details = ObjComplaint.Details,
                Incident_Date_And_Time = ObjComplaint.Incident_Date_And_Time,
                City = ObjComplaint.City,
                State = ObjComplaint.State,
                Information_Source = ObjComplaint.Information_Source,
                Additional_Information = ObjComplaint.Additional_Information,
            };
            return View(ObjViewModel);

        }

        [HttpPost,ValidateAntiForgeryToken,ValidateInput(true)]
        public ActionResult ApproveReject(int id)
        {
            var ObjRepository = new ComplaintsRepository();
            if(Request["btnApprove"]!=null)
            {
                ObjRepository.ApproveComplaint(id);
            }
            else
            {
                ObjRepository.RejectComplaint(id);
            }
            return RedirectToAction("PendingComplaints", "Admin");
        }


    }
}