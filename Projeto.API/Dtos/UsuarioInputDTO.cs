using Projeto.API.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class UsuarioInputDTO
{
    public int Id { get; set; }
    [Required, MaxLength(255)]
    public string Login { get; set; } = string.Empty;
    [Required, MaxLength(255)]
    public string Nome { get; set; } = string.Empty;
    [Required]
    public AutorizacaoEnum Autorizacao { get; set; }
    [Required]
    public string Senha { get; set; } = string.Empty;
    [Required]
    public bool Ativo { get; set; } = true;
}
