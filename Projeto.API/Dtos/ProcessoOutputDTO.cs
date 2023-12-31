﻿namespace Projeto.API.Dtos;

public class ProcessoOutputDTO
{
    public int Id { get; set; }
    public DateTime DataEnvio { get; set; } = new DateTime();
    public string ParaQuem { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int ItemArquivoId { get; set; }
    public ItemArquivoOutputDTO? ItemArquivo { get; set; }
}
