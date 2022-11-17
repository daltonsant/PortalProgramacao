using System.ComponentModel.DataAnnotations;

namespace PortalProgramacao.Web.Models;

public class UserModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Sobrenome")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Login")]
    public string UserName { get; set; }

    [Display(Name = "Usuário Admin?")]
    public bool IsAdmin {get; set;}

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirme sua senha")]
    [Compare("Password",ErrorMessage = "As senhas não conferem")]
    public string ConfirmPassword { get; set; }
}
