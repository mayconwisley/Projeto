namespace Projeto.WEB.Model
{
    public class TipoArquivoView
    {
        public int TotalDados { get; set; }
        public int Pagina { get; set; }
        public int TotalPagina { get; set; }
        public int Tamanho { get; set; }
        public IEnumerable<TipoArquivoDto>? Dados { get; set; }
    }
}
