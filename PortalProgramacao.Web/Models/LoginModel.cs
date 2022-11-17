using System.ComponentModel.DataAnnotations;

namespace PortalProgramacao.Web.Models;

public class LoginModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Login")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
}
