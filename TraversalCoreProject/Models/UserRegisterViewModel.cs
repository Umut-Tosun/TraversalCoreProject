using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
		public string SurName { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen E-posta adresinizi Giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor.")]
		[Required(ErrorMessage = "Lütfen Şifre tekrar Giriniz")]
		public string ConfirmPassword { get; set; }
		
		
	}
}
