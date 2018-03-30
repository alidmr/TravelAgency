using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Entities
{
    public class LoginViewModel
    {
        [DisplayName("E-Mail"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmak zorundadır."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmak zorundadır."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
