using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Entities
{
    public class RoleModel
    {
        [DisplayName("Rol Adı"),Required(ErrorMessage ="{0} alanı boş geçilemez."),StringLength(25,ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string RolName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
