using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BusinessLayer
{
    public class ServiceHelper
    {
        public List<Service> GetServicesList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Services.ToList();
            }
        }
        public Service GetServiceById(int serviceId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Services.FirstOrDefault(x => x.Id == serviceId);
            }
        }
        public int AddService(Service model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                model.CreatedDate = DateTime.Now;
                db.Services.Add(model);
                result = db.SaveChanges();
                return result;
            }
        }
        public int DeleteService(int serviceId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var service = GetServiceById(serviceId);
                if (service != null)
                {
                    db.Entry(service).State = System.Data.Entity.EntityState.Deleted;
                    db.Services.Remove(service);
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public int UpdateService(Service model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var service = GetServiceById(model.Id);
                if (service != null)
                {
                    service.Title = model.Title;
                    service.Detail = model.Detail;

                    db.Entry(service).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }

        public int GetServiceCount()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Services.Count();
            }
        }
    }
}
