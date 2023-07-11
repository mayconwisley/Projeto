using Projeto.API.Models.Enum;

namespace Projeto.API.Models;

public class TipoArquivo
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Guardar { get; set; } = 0;
    public TempoEnum Tempo { get; set; }
    public bool SuporteItem { get; set; }
    public bool SuporteControleCaixa { get; set; }
    public bool Ativo { get; set; } = true;
    public virtual IEnumerable<Arquivo>? Arquivos { get; set; }
    public virtual ControleCaixa? ControleCaixa { get; set; }

}
