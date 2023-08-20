namespace Projeto.WEB.Model;

public class UsuarioOutputDto
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Nome { get; set; }
    public string? Autorizacao { get; set; }
    public string? Senha { get; set; }
    public bool Ativo { get; set; } = true;
}
