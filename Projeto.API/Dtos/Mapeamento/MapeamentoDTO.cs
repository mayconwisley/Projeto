using AutoMapper;
using Projeto.API.Models;

namespace Projeto.API.Dtos.Mapeamento;

public class MapeamentoDTO : Profile
{
    public MapeamentoDTO()
    {
        CreateMap<TipoArquivo, TipoArquivoDTO>().ReverseMap();

        CreateMap<Usuario, UsuarioOutputDTO>();
        CreateMap<UsuarioInputDTO, Usuario>();

        CreateMap<Acesso, LoginDTO>().ReverseMap();

        CreateMap<ControleCaixa, ControleCaixaOutputDTO>();
        CreateMap<ControleCaixaInputDTO, ControleCaixa>();

        CreateMap<Arquivo, ArquivoOutputDTO>();
        CreateMap<ArquivoInputDTO, Arquivo>();

        CreateMap<Processo, ProcessoOutputDTO>();
        CreateMap<ProcessoInputDTO, Processo>();

        CreateMap<ItemArquivo, ItemArquivoOutputDTO>();
        CreateMap<ItemArquivoInputDTO, ItemArquivo>();
    }
}
