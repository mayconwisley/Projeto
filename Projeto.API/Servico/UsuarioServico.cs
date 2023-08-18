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
        var usuarios = await _usuarioRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<UsuarioOutputDTO>>(usuarios);
    }
    public async Task<IEnumerable<UsuarioOutputDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var usuariosAtivo = await _usuarioRepositorio.PegarTodosAtivos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<UsuarioOutputDTO>>(usuariosAtivo);
    }
    public async Task<UsuarioOutputDTO> PegarPorId(int id)
    {
        var usuario = await _usuarioRepositorio.PegarPorId(id);
        return _mapper.Map<UsuarioOutputDTO>(usuario);
    }
    public async Task<UsuarioOutputDTO> PegarPorLogin(string login)
    {
        var usuario = await _usuarioRepositorio.PegarPorLogin(login);
        return _mapper.Map<UsuarioOutputDTO>(usuario);
    }
    public async Task Criar(UsuarioInputDTO usuarioDTO)
    {
        UsuarioInputDTO usuarioDTOMap = new()
        {
            Id = usuarioDTO.Id,
            Login = usuarioDTO.Login,
            Nome = usuarioDTO.Nome,
            Senha = SenhaHash.Gerar(usuarioDTO.Senha),
            Autorizacao = usuarioDTO.Autorizacao,
            Ativo = usuarioDTO.Ativo
        };

        var usuario = _mapper.Map<Usuario>(usuarioDTOMap);
        await _usuarioRepositorio.Criar(usuario);
        usuarioDTO.Id = usuario.Id;
    }
    public async Task Atualizar(UsuarioInputDTO usuarioDTO)
    {
        UsuarioInputDTO usuarioDTOMap = new()
        {
            Id = usuarioDTO.Id,
            Login = usuarioDTO.Login,
            Nome = usuarioDTO.Nome,
            Senha = SenhaHash.Gerar(usuarioDTO.Senha),
            Autorizacao = usuarioDTO.Autorizacao,
            Ativo = usuarioDTO.Ativo
        };

        var usuarios = _mapper.Map<Usuario>(usuarioDTOMap);
        await _usuarioRepositorio.Atualizar(usuarios);
    }
    public async Task Deletar(int id)
    {
        var usuarioDTO = PegarPorId(id).Result;
        if (usuarioDTO is not null)
        {
            await _usuarioRepositorio.Deletar(usuarioDTO.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalUsuario = await _usuarioRepositorio.TotalDados(pesquisa);
        return totalUsuario;
    }
    public async Task<UsuarioOutputDTO> Acessar(LoginDTO acessoDTO)
    {
        LoginDTO acessoDTOMap = new()
        {
            Login = acessoDTO.Login,
            Senha = SenhaHash.Gerar(acessoDTO.Senha)
        };

        var acesso = _mapper.Map<Acesso>(acessoDTOMap);
        var usuario = await _usuarioRepositorio.Acessar(acesso);

        if (usuario.Login != "")
        {
            var usuarioDTO = await PegarPorLogin(acessoDTO.Login);
            return usuarioDTO;
        }
        return new UsuarioOutputDTO();
    }
}
