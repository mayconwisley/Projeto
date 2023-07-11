using Projeto.API.Models.Enum;

namespace Projeto.API.Models;

public class Arquivo
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public DateTime Competencia { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Ativo { get; set; } = true;
    public ArquiteturaEnum? Arquitetura { get; set; }
    public string? Pratelheira { get; set; }
    public string? PratelheiraLinha { get; set; }
    public string? PratelheiraColuna { get; set; }
    public string? Armario { get; set; }
    public string? Gaveta { get; set; }
    public DateTime DataDescarte { get; set; }
    public int NumCaixa { get; set; }
    public DateTime DataUltimAtualizacao { get; set; }
    public string? PrimeiroUsuarioCadastro { get; set; }
    public string? UltimoUsuarioAtualizar { get; set; }
    
    public int TipoArquivoId { get; set; }
    public TipoArquivo? TipoArquivo { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
