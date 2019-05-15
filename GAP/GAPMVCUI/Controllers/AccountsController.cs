using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAPMVCUI.Models;
using DataAccess;
using System.Web.Security;
namespace GAPMVCUI.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Anonymously()
        {
            //List<string> States = new List<string>() { "Andra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Orissa", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telagana", "Tripura", "Uttaranchal", "Uttar Pradesh", "West Bengal", "Andaman and Nicobar Islands", "Chandigarh", "Dadar and Nagar Haveli", "Daman and Diu", "Delhi", "Lakshadeep", "Pondicherry" };
            //SelectList ObjList = new SelectList(States);
            //ViewBag.StatesList = ObjList;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult Anonymously(ComplaintViewModel objModel)
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
                ObjComplaint.Status = objModel.Status;

                var Repository = new ComplaintsRepository();
                Repository.AddComplaint(ObjComplaint);

                ViewBag.Message = "Complaint submitted";
            }
            return View();
        }


        // GET: Accounts
        public ActionResult Register()
        {
            if (!User.Identity.IsAuthenticated && TempData.Peek("Usertype") == null)
            {
                return View();
            }
            else
            {
                if (TempData.Peek("Usertype").ToString() == "Admin")
                {
                    return RedirectToAction("PendingComplaints", "Admin");
                }
                else
                {
                    return RedirectToAction("ViewComplaints", "CmpLog");
                }
            }
        }

        public ActionResult Login()
        {
            if(!User.Identity.IsAuthenticated && TempData.Peek("Usertype") == null)
            {
                return View();
            }
            else
            {
                if (TempData.Peek("Usertype").ToString() == "Admin")
                {
                    return RedirectToAction("PendingComplaints", "Admin");
                }
                else
                {
                    return RedirectToAction("ViewComplaints", "CmpLog");
                }
            }
        }

        [HttpPost, ValidateInput(true), ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser ObjUser = new ApplicationUser();
                ObjUser.UserName = objModel.UserName;
                ObjUser.FirstName = objModel.FirstName;
                ObjUser.LastName = objModel.LastName;
                ObjUser.Password = objModel.Password;
                ObjUser.EmailAddress = objModel.EmailAddress;
                ObjUser.UserType = ApplicationUserType.User;

                var Repository = new UsersRepository();
                Repository.AddUser(ObjUser);

                ViewBag.Message = "Registration successful";
            }
            return View(objModel);
        }

        [HttpPost, ValidateInput(true), ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel objModel)
        {
            if (ModelState.IsValid)
            {
                var Repository = new UsersRepository();
                var IsValid = Repository.VerifyUser(objModel.UserName, objModel.Password);
                if (IsValid == false)
                {
                    ViewBag.Message = "Invalid username/password";
                    return View(objModel);
                }
                else
                {
                    var UserType = Repository.GetUserType(objModel.UserName).ToString();
                    TempData["Usertype"] = UserType;
                    FormsAuthentication.SetAuthCookie(objModel.UserName, objModel.RememberMe);
                    if(UserType=="Admin")
                    {
                        return RedirectToAction("PendingComplaints", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Create", "CmpLog");
                    }
                }
            }
            return View(objModel);
        } 

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData.Remove("Usertype");
            return RedirectToAction("Login","Accounts");
        }
    }
}