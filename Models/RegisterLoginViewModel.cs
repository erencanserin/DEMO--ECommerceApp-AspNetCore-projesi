using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class RegisterLoginViewModel : IValidatableObject
    {
        // Kayýt alanlarý
        [Required(ErrorMessage = "Kullanýcý adý zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alaný zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Þifre alaný zorunludur.")]
        [MinLength(6, ErrorMessage = "Þifre en az 6 karakter olmalýdýr.")]
        public string Password { get; set; }

        // Giriþ alanlarý
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }

        // Login için mi kayýt için mi geldiðini ayýrmak için
        public bool IsLogin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsLogin)
            {
                if (string.IsNullOrWhiteSpace(LoginEmail))
                    yield return new ValidationResult("Email alaný zorunludur.", new[] { nameof(LoginEmail) });

                if (string.IsNullOrWhiteSpace(LoginPassword))
                    yield return new ValidationResult("Þifre alaný zorunludur.", new[] { nameof(LoginPassword) });
            }
            else
            {
                if (string.IsNullOrWhiteSpace(UserName))
                    yield return new ValidationResult("Kullanýcý adý zorunludur.", new[] { nameof(UserName) });

                if (string.IsNullOrWhiteSpace(Email))
                    yield return new ValidationResult("Email alaný zorunludur.", new[] { nameof(Email) });

                if (string.IsNullOrWhiteSpace(Password))
                    yield return new ValidationResult("Þifre alaný zorunludur.", new[] { nameof(Password) });
            }
        }
    }
}
