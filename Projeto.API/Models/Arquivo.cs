using Projeto.API.Models.Enum;

namespace Projeto.API.Models;

public class Arquivo
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime Competencia { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Ativo { get; set; } = true;
    public ArquiteturaEnum Arquitetura { get; set; }
    public string Pratelheira { get; set; } = string.Empty;
    public string PratelheiraLinha { get; set; } = string.Empty;
    public string PratelheiraColuna { get; set; } = string.Empty;
    public string Armario { get; set; } = string.Empty;
    public string Gaveta { get; set; } = string.Empty;
    public DateTime DataDescarte { get; set; }
    public int NumeroCaixa { get; set; }
    public DateTime DataUltimaAtualizacao { get; set; }
    public string PrimeiroUsuarioCadastro { get; set; } = string.Empty;
    public string UltimoUsuarioAtualizar { get; set; } = string.Empty;

    public int TipoArquivoId { get; set; }
    public virtual TipoArquivo? TipoArquivo { get; set; }

    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
