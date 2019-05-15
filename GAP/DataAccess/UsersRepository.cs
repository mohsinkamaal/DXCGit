using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsersRepository
    {
        public void AddUser(ApplicationUser objUser)
        {
            try
            {
                using (var ObjContext = new GAPContext())
                {
                    ObjContext.ApplicationUsers.Add(objUser);
                    ObjContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerifyUser(string username, string password)
        {
            bool IsValidUser = false;
            try
            {
                using (var ObjContext = new GAPContext())
                {
                    var NoOfUsers = (from obj in ObjContext.ApplicationUsers
                                     where obj.UserName == username && obj.Password == password
                                     select obj).Count();
                    IsValidUser = NoOfUsers > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsValidUser;
        }

        public ApplicationUserType GetUserType(string username)
        {
            ApplicationUserType UserType = ApplicationUserType.User;
            try
            {
                using (var ObjContext = new GAPContext())
                {
                    UserType = (from obj in ObjContext.ApplicationUsers
                                where obj.UserName == username
                                select obj.UserType).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return UserType;
        }
    }
}
