﻿namespace Projeto.API.Dtos;

public class ItemArquivoOutputDTO
{
    public int Id { get; set; }
    public string CodigoItem { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool NoArquivo { get; set; }
    public int ArquivoId { get; set; }
    public ArquivoOutputDTO? Arquivo { get; set; }
}
