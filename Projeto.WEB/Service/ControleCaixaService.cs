using Projeto.WEB.Model;
using Projeto.WEB.Service.Interface;
using System.Net.Http.Json;
using System.Text.Json;

namespace Projeto.WEB.Service
{
    public class ControleCaixaService : IControleCaixaService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _serializerOptions;
        private const string? apiEndPoint = "api/ControleCaixa";
        private readonly ControleCaixaInputDto controleCaixaInputDto = new();
        private readonly ControleCaixaOutputDto controleCaixaOutputDto = new();
        private readonly ControleCaixaOutputView controleCaixaOutputView = new();

        public ControleCaixaService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serializerOptions = _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<ControleCaixaInputDto> Atualizar(ControleCaixaInputDto controleCaixaInput)
        {
            throw new NotImplementedException();
        }

        public Task<ControleCaixaInputDto> Cadastrar(ControleCaixaInputDto controleCaixaInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ControleCaixaOutputDto> PegarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ControleCaixaOutputView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "")
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("ConexaoApi");

                var controleCaixaView = await httpClient.GetFromJsonAsync<ControleCaixaOutputView>(apiEndPoint + $"?pagina={pagina}&tamanho={tamanho}&pesquisa={pesquisa}");

                if (controleCaixaView is not null)
                {
                    return controleCaixaView;
                }
                return new ControleCaixaOutputView();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ControleCaixaOutputView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "")
        {
            throw new NotImplementedException();
        }
    }
}
