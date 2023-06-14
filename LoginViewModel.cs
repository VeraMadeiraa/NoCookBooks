using System.ComponentModel.DataAnnotations;

namespace NoCookBooks.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
