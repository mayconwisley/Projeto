namespace Projeto.WEB.Model
{
    public class ControleCaixaOutputView
    {
        public int TotalDados { get; set; }
        public int Pagina { get; set; }
        public int TotalPagina { get; set; }
        public int Tamanho { get; set; }
        public IEnumerable<ControleCaixaOutputDto>? Dados { get; set; }
    }
}
