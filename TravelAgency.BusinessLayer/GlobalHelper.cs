using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TravelAgency.BusinessLayer
{
    public class GlobalHelper
    {
        public string saveImage(HttpPostedFileBase document, string eski)
        {
            if (document != null)
            {
                string url = HttpContext.Current.Server.MapPath("~/" +eski);
                if (File.Exists(url) && !string.IsNullOrEmpty(eski))
                {
                    File.Delete(url);
                }
                //FileInfo f = new FileInfo(document.FileName);

                string filename = $"{Guid.NewGuid()}.{document.ContentType.Split('/')[1]}";
                
                string path = "Content/image/" + filename;
                document.SaveAs(HttpContext.Current.Server.MapPath("~/" + path));
                return path;
            }
            else
            {
                return "";
            }
        }
    }
}
