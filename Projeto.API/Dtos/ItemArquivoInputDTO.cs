using System.ComponentModel.DataAnnotations;

namespace Projeto.API.Dtos;

public class ItemArquivoInputDTO
{
    public int Id { get; set; }
    public string CodigoItem { get; set; } = string.Empty;
    [Required, MaxLength(500)]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public bool NoArquivo { get; set; } = true;
    [Required]
    public int ArquivoId { get; set; }

}
