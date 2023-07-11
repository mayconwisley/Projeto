using Microsoft.IdentityModel.Tokens;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;
using Projeto.API.Ultilitario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto.API.Servico;

public class TokenServico : ITokenServico
{
    public Task<string> GerarToken(UsuarioOutputDTO usuarioDTO)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Chave.Secreto);
        var tokenDescricao = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,  usuarioDTO.Login),
                new Claim(ClaimTypes.Role, usuarioDTO.Autorizacao.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescricao);
        return Task.FromResult($"Bearer {tokenHandler.WriteToken(token)}");
    }
}
