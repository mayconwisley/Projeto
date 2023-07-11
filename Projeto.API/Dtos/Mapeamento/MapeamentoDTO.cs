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
        
        CreateMap<ControleCaixa, ControleCaixaOutputDTO>().ReverseMap();
        
        CreateMap<Arquivo, ArquivoInputDTO>().ReverseMap();
        CreateMap<Arquivo, ArquivoOutputDTO>();

        CreateMap<Processo, ProcessoOutputDTO>().ReverseMap();
        CreateMap<ItemArquivo, ItemArquivoOutputDTO>().ReverseMap();
    }
}
