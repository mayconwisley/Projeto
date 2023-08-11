using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class LoginDTO
{
    [Required]
    public string Login { get; set; } = string.Empty;
    [Required]
    public string Senha { get; set; } = string.Empty;
}
