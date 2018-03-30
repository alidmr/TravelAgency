using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Entities;
using System.Web;
using System.Transactions;

namespace TravelAgency.BusinessLayer
{
    public class ContentHelper : IDisposable
    {
        public List<Content> GetContentList()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Contents.Include("ContentImages").Include("Category").ToList();
            }
        }
        public Content GetContentsById(int contentId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Contents.FirstOrDefault(x => x.Id == contentId);
            }
        }
        public ContentImage GetImageById(int imageId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.ContentImages.FirstOrDefault(x => x.Id == imageId);
            }
        }
        public int AddContent(ContentViewModel contentModel)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                using (TransactionScope scp = new TransactionScope())
                {
                    int result = 0;
                    Content content = new Content()
                    {
                        Title = contentModel.Content_Title,
                        Detail = contentModel.Content_Detail,
                        Panel = contentModel.IsPanel,
                        IsActive = true,
                        Price = contentModel.Price,
                        Location = contentModel.Location,
                        StartDate = contentModel.StartDate,
                        FinishDate = contentModel.FinishDate,
                        Rate = contentModel.Rate,
                        NumberPeople = contentModel.NumberPeople,
                        Category_Id = contentModel.Category,
                        Created_Date = DateTime.Now,
                    };
                    db.Contents.Add(content);
                    result = db.SaveChanges();

                    var imageLst = contentModel.Image;
                    if (imageLst.Count > 0)
                    {
                        foreach (var item in imageLst)
                        {
                            HttpPostedFileBase dx = (HttpPostedFileBase)item;
                            ContentImage cti = new ContentImage()
                            {
                                Original_Image_Path = new GlobalHelper().saveImage(dx, ""),
                                Created_Date = DateTime.Now,
                                Content_Id = content.Id
                            };
                            db.ContentImages.Add(cti);
                            db.SaveChanges();
                        }
                    }


                    scp.Complete();
                    return result;
                }

            }
        }
        public int DeleteContent(int contentId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var content = GetContentsById(contentId);

                if (content != null)
                {
                    var images = db.ContentImages.Where(x => x.Content_Id == content.Id).ToList();

                    if (images.Count > 0)
                    {
                        foreach (var item in images)
                        {
                            db.Entry(item).State = EntityState.Deleted;
                            db.ContentImages.Remove(item);
                            db.SaveChanges();
                        }
                    }


                    db.Entry(content).State = EntityState.Deleted;
                    db.Contents.Remove(content);
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public int UpdateContent(Content model)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var content = GetContentsById(model.Id);
                if (content != null)
                {
                    content.Title = model.Title;
                    content.Detail = model.Detail;
                    content.IsActive = model.IsActive;
                    content.Panel = model.Panel;
                    content.Price = model.Price;
                    content.Location = model.Location;
                    content.StartDate = model.StartDate;
                    content.FinishDate = model.FinishDate;
                    content.Rate = model.Rate;
                    content.NumberPeople = model.NumberPeople;
                    content.Category_Id = model.Category_Id;

                    db.Entry(content).State = EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }

        public bool DeleteContentImage(int id)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                bool result = false;
                var image = GetImageById(id);
                if (image != null)
                {
                    db.Entry(image).State = EntityState.Deleted;
                    db.ContentImages.Remove(image);
                    int resultx = db.SaveChanges();
                    result = resultx == 1 ? true : false;
                }
                return result;
            }
        }
        public int UpdateContentImage(ContentImage model, HttpPostedFileBase newimage)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                //object modelImage = model.Original_Image_Path;
                //HttpPostedFileBase img = modelImage as HttpPostedFileBase;
                if (newimage != null)
                {
                    string newImagePath = new GlobalHelper().saveImage(newimage, model.Original_Image_Path);

                    var image = GetImageById(model.Id);
                    if (image != null)
                    {
                        image.Original_Image_Path = newImagePath;

                        db.Entry(image).State = EntityState.Modified;
                        result = db.SaveChanges();
                    }
                }
                return result;
            }
        }

        public int UpdateStatus(int id)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                int result = 0;
                var content = GetContentsById(id);
                if (content != null)
                {
                    if (content.IsActive == true)
                    {
                        content.IsActive = false;
                    }
                    else
                    {
                        content.IsActive = true;
                    }
                    db.Entry(content).State = EntityState.Modified;
                    result = db.SaveChanges();
                }
                return result;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public Content GetContentsDetailById(int contentId)
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Contents.Include("ContentImages").Include("Category").FirstOrDefault(x => x.Id == contentId);
            }
        }

        public int GetContentCount()
        {
            using (TurizmWebEntities db = new TurizmWebEntities())
            {
                return db.Contents.Count();
            }
        }
    }
}
