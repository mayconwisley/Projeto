using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Model;

public class UsuarioInputDto
{
    [Required]
    public string? Login { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Autorizacao { get; set; }
    [Required]
    public string? Senha { get; set; }
    public bool Ativo { get; set; } = true;
}
