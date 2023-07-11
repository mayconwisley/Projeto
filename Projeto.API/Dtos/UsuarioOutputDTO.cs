using Projeto.API.Models.Enum;

namespace Projeto.API.Dtos;

public class UsuarioOutputDTO
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public AutorizacaoEnum Autorizacao { get; set; }
    public bool Ativo { get; set; } = true;
}
