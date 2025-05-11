using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class RegisterLoginViewModel : IValidatableObject
    {
        // Kay�t alanlar�
        [Required(ErrorMessage = "Kullan�c� ad� zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alan� zorunludur.")]
        [EmailAddress(ErrorMessage = "Ge�erli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "�ifre alan� zorunludur.")]
        [MinLength(6, ErrorMessage = "�ifre en az 6 karakter olmal�d�r.")]
        public string Password { get; set; }

        // Giri� alanlar�
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }

        // Login i�in mi kay�t i�in mi geldi�ini ay�rmak i�in
        public bool IsLogin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsLogin)
            {
                if (string.IsNullOrWhiteSpace(LoginEmail))
                    yield return new ValidationResult("Email alan� zorunludur.", new[] { nameof(LoginEmail) });

                if (string.IsNullOrWhiteSpace(LoginPassword))
                    yield return new ValidationResult("�ifre alan� zorunludur.", new[] { nameof(LoginPassword) });
            }
            else
            {
                if (string.IsNullOrWhiteSpace(UserName))
                    yield return new ValidationResult("Kullan�c� ad� zorunludur.", new[] { nameof(UserName) });

                if (string.IsNullOrWhiteSpace(Email))
                    yield return new ValidationResult("Email alan� zorunludur.", new[] { nameof(Email) });

                if (string.IsNullOrWhiteSpace(Password))
                    yield return new ValidationResult("�ifre alan� zorunludur.", new[] { nameof(Password) });
            }
        }
    }
}
