using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BusinessLayer
{
    public class CategoryHelper
    {
        //ADMİN PANELİ
        public List<Category> GetCategoryList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Categories.ToList();
            }
        }
        public Category GetCategoryById(int categoryId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Categories.FirstOrDefault(x => x.Id == categoryId);
            }
        }
        public int DeleteCategory(int categoryid)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var category = GetCategoryById(categoryid);
                if (category != null)
                {
                    db.Entry(category).State = EntityState.Deleted;
                    db.Categories.Remove(category);
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public int AddCategory(Category model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                model.Created_Date = DateTime.Now;
                db.Categories.Add(model);
                result = db.SaveChanges();
                return result;
            }
        }
        public int UpdateCategory(Category model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var category_ = GetCategoryById(model.Id);
                if (category_ != null)
                {
                    category_.Name = model.Name;
                    category_.Description = model.Description;
                    db.Entry(category_).State = EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        // buraya kadar olan metotlar admin paneli için çalışan metotlar

        //WEB UI 
        public List<Category> GetCategoryContentList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Categories.Include(e=>e.Contents).Include(e=>e.Contents.Select(w=>w.ContentImages)).ToList();
            }
        }

        public int GetCategoryCount()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Categories.Count();
            }
        }
    }
}
