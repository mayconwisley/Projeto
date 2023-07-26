namespace Projeto.WEP.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Autorizacao { get; set; }
        public bool Ativo { get; set; }
    }
    public class UsuarioToken
    {
        public UsuarioViewModel UsuarioDTO { get; set; }
        public string token { get; set; }
    }
}
