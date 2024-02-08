using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockMVC.Domain.Models
{
    public class UserCredentialDto
    {
        [Required(ErrorMessage = "*El correo es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "*La contraseña es obligatoria")]
        public string Password { get; set; } = string.Empty;
    }
}
