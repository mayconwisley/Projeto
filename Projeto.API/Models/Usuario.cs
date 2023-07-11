using Projeto.API.Models.Enum;

namespace Projeto.API.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public AutorizacaoEnum Autorizacao { get; set; }
    public string Senha { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
    public virtual IEnumerable<Arquivo>? Arquivos { get; set; }
}
