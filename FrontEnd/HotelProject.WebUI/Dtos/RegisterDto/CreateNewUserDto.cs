using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadı alanı gereklidir")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı gereklidir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mail alanı gereklidir")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Şifre Tekrar alanı gereklidir")]
        [Compare("Password", ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        public int WorkLocationID { get; set; }
    }
}
