using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities;

namespace TravelAgency.BusinessLayer
{
    public class RoleHelper : IDisposable
    {
        public List<Role> GetRoleList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Roles.ToList();
            }
        }
        public int AddRole(RoleModel model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                Role rl = new Role()
                {
                    Role_Name = model.RolName,
                    Created_Date = model.CreatedDate
                };
                int sonuc = 0;
                db.Roles.Add(rl);
                sonuc = db.SaveChanges();
                return sonuc;
            }
        }
        public int DeleteRole(int id)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var role = GetRoleById(id);
                if (role != null)
                {
                    db.Entry(role).State = System.Data.Entity.EntityState.Deleted;
                    db.Roles.Remove(role);
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public Role GetRoleById(int roleid)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Roles.FirstOrDefault(x => x.Id == roleid);
            }
        }
        public int UpdateRole(Role model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var role = GetRoleById(model.Id);
                if (role != null)
                {
                    role.Role_Name = model.Role_Name;
                    db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
