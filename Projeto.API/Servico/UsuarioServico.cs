using AutoMapper;
using Projeto.API.Dtos;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;
using Projeto.API.Servico.Interface;
using Projeto.API.Ultilitario;

namespace Projeto.API.Servico;

public class UsuarioServico : IUsuarioServico
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;

    public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var usuarioEntity = await _usuarioRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<UsuarioOutputDTO>>(usuarioEntity);
    }
    public async Task<IEnumerable<UsuarioOutputDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var usuarioEntityAtivo = await _usuarioRepositorio.PegarTodosAtivos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<UsuarioOutputDTO>>(usuarioEntityAtivo);
    }
    public async Task<UsuarioOutputDTO> PegarPorId(int id)
    {
        var usuarioEntity = await _usuarioRepositorio.PegarPorId(id);
        return _mapper.Map<UsuarioOutputDTO>(usuarioEntity);

    }
    public async Task<UsuarioOutputDTO> PegarPorLogin(string login)
    {
        var usuarioEntity = await _usuarioRepositorio.PegarPorLogin(login);
        return _mapper.Map<UsuarioOutputDTO>(usuarioEntity);
    }
    public async Task Criar(UsuarioInputDTO usuario)
    {
        UsuarioInputDTO usuarioDTO = new()
        {
            Id = usuario.Id,
            Login = usuario.Login,
            Nome = usuario.Nome,
            Senha = SenhaHash.Gerar(usuario.Senha),
            Autorizacao = usuario.Autorizacao,
            Ativo = usuario.Ativo
        };

        var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepositorio.Criar(usuarioEntity);
        usuarioDTO.Id = usuarioEntity.Id;

    }
    public async Task Atualizar(UsuarioInputDTO usuario)
    {
        UsuarioInputDTO usuarioDTO = new()
        {
            Id = usuario.Id,
            Login = usuario.Login,
            Nome = usuario.Nome,
            Senha = SenhaHash.Gerar(usuario.Senha),
            Autorizacao = usuario.Autorizacao,

            Ativo = usuario.Ativo
        };

        var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepositorio.Atualizar(usuarioEntity);
    }
    public async Task Deletar(int id)
    {
        var usuarioEntity = PegarPorId(id).Result;
        if (usuarioEntity is not null)
        {
            await _usuarioRepositorio.Deletar(usuarioEntity.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalUsuario = await _usuarioRepositorio.TotalDados(pesquisa);
        return totalUsuario;
    }

    public async Task<UsuarioOutputDTO> Acessar(AcessoDTO acesso)
    {
        AcessoDTO acessoDTO = new()
        {
            Usuario = acesso.Usuario,
            Senha = SenhaHash.Gerar(acesso.Senha)
        };


        var acessoEntity = _mapper.Map<Acesso>(acessoDTO);
        var acessoLogin = await _usuarioRepositorio.Acessar(acessoEntity);

        if (acessoLogin.Login != "")
        {
            var usuarioDTO = await PegarPorLogin(acesso.Usuario);
            return usuarioDTO;
        }
        return new UsuarioOutputDTO();
    }


}
