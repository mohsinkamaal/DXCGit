using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ComplaintsRepository
    {
        public int AddComplaint(Complaints objComplaints)
        {
            try
            {
                using (var ObjContext = new GAPContext())
                {
                    ObjContext.Complaints.Add(objComplaints);
                    ObjContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objComplaints.Id;
        }

        public IEnumerable<Complaints> ViewAllApprovedComplaints()
        {
            List<Complaints> ObjComplaints = new List<Complaints>();
            try
            {
                using (var ObjContext = new GAPContext())
                {
                    var Query = from obj in ObjContext.Complaints
                                where obj.Status == ComplaintStatus.Approved
                                select new { obj.Id, obj.Category_Of_Crime, obj.Suspect_Name, obj.Details, obj.Incident_Date_And_Time, obj.City, obj.State, obj.Information_Source, obj.Additional_Information };

                    foreach (var item in Query)
                    {
                        ObjComplaints.Add(new Complaints { Id = item.Id, Category_Of_Crime = item.Category_Of_Crime, Suspect_Name = item.Suspect_Name, Details = item.Details, Incident_Date_And_Time = item.Incident_Date_And_Time, City = item.City, State = item.State, Information_Source = item.Information_Source, Additional_Information = item.Additional_Information });
                    }

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ObjComplaints;



        }



        public IEnumerable<Complaints> ViewComplaintsByUserName(string username)

        {

            List<Complaints> ObjComplaints = new List<Complaints>();

            try

            {

                using (var ObjContext = new GAPContext())

                {

                    var Query = from obj in ObjContext.Complaints

                                where obj.UserName == username

                                select new

                                {

                                    obj.Id,

                                    obj.Category_Of_Crime,

                                    obj.Suspect_Name,

                                    obj.Details,

                                    obj.Incident_Date_And_Time

                                };

                    foreach (var item in Query)

                    {

                        ObjComplaints.Add(new Complaints { Id = item.Id, Category_Of_Crime = item.Category_Of_Crime, Suspect_Name = item.Suspect_Name, Details = item.Details, Incident_Date_And_Time = item.Incident_Date_And_Time });

                    }

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ObjComplaints;

        }



        public IEnumerable<Complaints> ViewPendingComplaints()

        {

            List<Complaints> ObjComplaints = new List<Complaints>();

            try

            {

                using (var ObjContext = new GAPContext())

                {

                    var Query = from obj in ObjContext.Complaints

                                where obj.Status == ComplaintStatus.Pending

                                select new { obj.Id, obj.Category_Of_Crime, obj.Suspect_Name };

                    foreach (var item in Query)

                    {

                        ObjComplaints.Add(new Complaints { Id = item.Id, Category_Of_Crime = item.Category_Of_Crime, Suspect_Name = item.Suspect_Name });

                    }

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ObjComplaints;

        }



        public void ApproveComplaint(int id)

        {

            try

            {

                using (var ObjContext = new GAPContext())

                {
                    var ObjComplaint = ObjContext.Complaints.Find(id);

                    ObjComplaint.Status = ComplaintStatus.Approved;

                    ObjContext.SaveChanges();

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }



        public void RejectComplaint(int id)

        {

            try

            {

                using (var ObjContext = new GAPContext())

                {

                    var ObjComplaint = ObjContext.Complaints.Find(id);

                    ObjComplaint.Status = ComplaintStatus.Rejected;

                    ObjContext.SaveChanges();

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }



        public Complaints ViewComplaintById(int id)

        {

            Complaints ObjComplaint = null;

            try

            {

                using (var ObjContext = new GAPContext())

                {

                    ObjComplaint = ObjContext.Complaints.Find(id);

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ObjComplaint;

        }


        public Complaints ViewStatus(int id)
        {
            var objContext = new GAPContext();
            var Query = (from item in objContext.Complaints
                         where item.Id == id
                         select item).FirstOrDefault();

            if (Query != null)
            {
                var ob = Query.Status;
                
            }
            return Query;

        }


    }

}