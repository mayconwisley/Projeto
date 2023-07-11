﻿using Projeto.API.Models.Enum;

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
    public int NumCaixa { get; set; }
    public DateTime DataUltimAtualizacao { get; set; }
    public string PrimeiroUsuarioCadastro { get; set; } = string.Empty;
    public string UltimoUsuarioAtualizar { get; set; } = string.Empty;

    public int TipoArquivoId { get; set; }
    public TipoArquivo TipoArquivo { get; set; } = new TipoArquivo();
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = new Usuario();
}
