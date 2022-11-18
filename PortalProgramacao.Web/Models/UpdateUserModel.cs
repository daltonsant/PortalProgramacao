using System.ComponentModel.DataAnnotations;

namespace PortalProgramacao.Web.Models;

public class UpdateUserModel
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

    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [DataType(DataType.Password)]
    [Display(Name = "Nova Senha")]
    public string? Password { get; set; }
    
    [DataType(DataType.Password)]
    [Display(Name = "Confirme nova senha")]
    [Compare("Password",ErrorMessage = "As senhas não conferem")]
    public string? ConfirmPassword { get; set; }
}