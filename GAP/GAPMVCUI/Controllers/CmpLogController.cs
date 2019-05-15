using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAPMVCUI.Models;
using DataAccess;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GAPMVCUI.Controllers
{
    [Authorize]
    public class CmpLogController : Controller
    {
      
        // GET: CmpLog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //List <string> States = new List<string>() { "Andra Pradesh","Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Orissa", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telagana", "Tripura", "Uttaranchal", "Uttar Pradesh", "West Bengal", "Andaman and Nicobar Islands", "Chandigarh", "Dadar and Nagar Haveli", "Daman and Diu", "Delhi", "Lakshadeep", "Pondicherry" };
            //SelectList ObjList = new SelectList();
            //ViewBag.StatesList = ObjList;
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Create(ComplaintViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                var ObjComplaint = new Complaints();
                ObjComplaint.Category_Of_Crime = objModel.Category_Of_Crime;
                ObjComplaint.Suspect_Name = objModel.Suspect_Name;
                ObjComplaint.Details = objModel.Details;
                ObjComplaint.Incident_Date_And_Time = objModel.Incident_Date_And_Time;
                ObjComplaint.City = objModel.City;
                ObjComplaint.State = objModel.State;
                ObjComplaint.Information_Source = objModel.Information_Source;
                ObjComplaint.Additional_Information = objModel.Additional_Information;
                ObjComplaint.Status = ComplaintStatus.Pending;
                ObjComplaint.UserName = User.Identity.Name;

                var Repository = new ComplaintsRepository();
                var TrackId = Repository.AddComplaint(ObjComplaint);

               // ViewBag.Message = "Complaint submitted";
                ViewBag.Message = TrackId;
            }
            return View(objModel);
        }

        public ActionResult Complaints()
        {
            var UserId = User.Identity.Name;
            var Repository = new ComplaintsRepository();
            var ObjComplaints = Repository.ViewComplaintsByUserName(UserId);
            var ObjViewModel = new List<ComplaintViewModel>();
            foreach(var item in ObjComplaints)
            {
                ObjViewModel.Add(new ComplaintViewModel { Id = item.Id, Category_Of_Crime = item.Category_Of_Crime, Suspect_Name = item.Suspect_Name, Details = item.Details, Incident_Date_And_Time = item.Incident_Date_And_Time });
            }
            return View(ObjViewModel);
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

        public ActionResult ViewComplaints()
        {
            var Repository = new ComplaintsRepository();
            var ObjComplaints = Repository.ViewAllApprovedComplaints();
            var ObjModel = new List<ComplaintViewModel>();
            foreach(var item in ObjComplaints)
            {
                ObjModel.Add(new ComplaintViewModel
                {
                    Id = item.Id,
                    Category_Of_Crime = item.Category_Of_Crime,
                    Suspect_Name = item.Suspect_Name,
                    Details = item.Details,
                    Incident_Date_And_Time = item.Incident_Date_And_Time,
                    City = item.City,
                    State = item.State,
                    Information_Source = item.Information_Source,
                    Additional_Information = item.Additional_Information
                });
            }
            return View(ObjModel);
        }

        public ActionResult TrackStatus()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult TrackStatus(ComplaintViewModel obj)
        {
             var id = obj.Id;
            var objContext = new GAPContext();
            var Query = (from item in objContext.Complaints
                         where item.Id == id
                         select item).FirstOrDefault();

            if (Query != null)
            {

            ViewBag.status = Query.Status;

            }
            return View();
            
        }

    



    }
}