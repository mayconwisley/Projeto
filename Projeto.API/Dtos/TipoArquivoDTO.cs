using Projeto.API.Models.Enum;

namespace Projeto.API.Dtos;

public class TipoArquivoDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Guardar { get; set; } = 0;
    public TempoEnum Tempo { get; set; }
    public bool SuporteItem { get; set; }
    public bool SuporteControleCaixa { get; set; }
    public bool Ativo { get; set; } = true;
}
