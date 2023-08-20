using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Model;

public class TipoArquivoDto
{
    public int Id { get; set; }
    [Required]
    public string? Descricao { get; set; }
    [Required]
    public int Guardar { get; set; }
    [Required]
    public int Tempo { get; set; }
    public bool SuporteItem { get; set; }
    public bool SuporteControleCaixa { get; set; }
    public bool Ativo { get; set; } = true;

}
