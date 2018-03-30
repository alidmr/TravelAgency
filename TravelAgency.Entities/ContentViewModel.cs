using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TravelAgency.Entities
{
    public class ContentViewModel
    {
        [DisplayName("İçerik Başlığı"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Content_Title { get; set; }

        [DisplayName("İçerik Detayı"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Content_Detail { get; set; }
        [DisplayName("Ön Panel")]
        public bool IsPanel { get; set; }
        [DisplayName("Görseller")]
        public List<object> Image { get; set; }
        [DisplayName("Kategori")]
        public int Category { get; set; }
        [DisplayName("Fiyat"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Price { get; set; }
        [DisplayName("Konum"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Location { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [DisplayName("Bitiş Tarihi")]
        public DateTime FinishDate { get; set; }
        [DisplayName("Kişi Sayısı")]
        public int NumberPeople { get; set; }
        [DisplayName("Derece")]
        public int Rate { get; set; }
    }
}
