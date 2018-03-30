using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities;

namespace TravelAgency.BusinessLayer
{
    public class UserHelper
    {
        #region admin paneli işlemleri
        public List<User> GetUserList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Users.Include("Role").ToList();
            }
        }
        public User GetUserById(int userId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Users.FirstOrDefault(x => x.Id == userId);
            }
        }
        public int AddUser(User model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                model.Created_Date = DateTime.Now;
                db.Users.Add(model);
                result = db.SaveChanges();
                return result;
            }
        }

        public int DeleteUser(int id)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var user = GetUserById(id);

                if (user != null)
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                    db.Users.Remove(user);
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public int UpdateUser(User model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var user = GetUserById(model.Id);
                if (user != null)
                {
                    user.First_Name = model.First_Name;
                    user.Last_Name = model.Last_Name;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Role_Id = model.Role_Id;

                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public int GetUsertCount()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Users.Count();
            }
        }
        #endregion


        #region user login işlemleri
        public User Login(LoginViewModel loginModel)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                var user = db.Users.FirstOrDefault(x => x.Email == loginModel.Email & x.Password == loginModel.Password);
                if (user != null)
                {
                    return user as User;
                }
                return null;
            }
        }
        #endregion
    }
}
