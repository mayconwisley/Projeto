using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Model;

public class LoginDto
{
    [Required]
    public string Login { get; set; } = string.Empty;
    [Required]
    public string Senha { get; set; } = string.Empty;
}
