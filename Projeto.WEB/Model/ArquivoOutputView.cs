namespace Projeto.WEB.Model
{
    public class ArquivoOutputView
    {
        public int TotalDados { get; set; }
        public int Pagina { get; set; }
        public int TotalPagina { get; set; }
        public int Tamanho { get; set; }
        public IEnumerable<ArquivoOutputDto>? Dados { get; set; }
    }
}
