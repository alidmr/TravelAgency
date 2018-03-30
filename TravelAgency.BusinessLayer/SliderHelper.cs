using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BusinessLayer
{
    public class SliderHelper
    {
        public List<Slider> GetSliderList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Sliders.ToList();
            }
        }
        public Slider GetSliderById(int sliderId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Sliders.FirstOrDefault(x => x.Id == sliderId);
            }
        }
        public int AddSlider(Slider model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                model.CreatedDate = DateTime.Now;

                db.Sliders.Add(model);
                result = db.SaveChanges();
                return result;
            }
        }
        public int DeleteSlider(int id)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var slider = GetSliderById(id);
                if (slider != null)
                {
                    db.Entry(slider).State = System.Data.Entity.EntityState.Deleted;
                    db.Sliders.Remove(slider);
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public int UpdateSlider(Slider model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var slider = GetSliderById(model.Id);
                if (slider != null)
                {
                    slider.Title = model.Title;
                    slider.Description = model.Description;
                    db.Entry(slider).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }
    }
}
