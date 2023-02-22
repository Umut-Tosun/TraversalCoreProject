using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProject.Models
{
	public class CustomİdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = $"Parola en az 1 rakam içermelidir ('0'.'9')."
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = $"Parola en az {length} karakter içermelidir ."
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = $"Parola en az 1 küçük harf içermelidir ."
			};
		}
		public override IdentityError PasswordRequiresUpper() 
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = $"Parola en az 1 büyük harf içermelidir ."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = $"Parola en az 1 sembol içermelidir ."
			};
		}


	}
}
