using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Zorunludur.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Zorunludur.")]
        public string Password { get; set; } 
    }
}
