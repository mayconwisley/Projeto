using AutoMapper;
using Projeto.API.Models;

namespace Projeto.API.Dtos.Mapeamento;

public class MapeamentoDTO : Profile
{
    public MapeamentoDTO()
    {
        CreateMap<TipoArquivo, TipoArquivoDTO>().ReverseMap();
        CreateMap<Usuario, UsuarioInputDTO>().ReverseMap();
        CreateMap<Usuario, UsuarioOutputDTO>();
        CreateMap<Acesso, AcessoDTO>().ReverseMap();
        CreateMap<ControleCaixa, ControleCaixaDTO>().ReverseMap();
        CreateMap<Arquivo, ArquivoDTO>().ReverseMap();
        CreateMap<Processo, ProcessoDTO>().ReverseMap();
        CreateMap<ItemArquivo, ItemArquivoDTO>().ReverseMap();
    }
}
