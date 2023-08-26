using Projeto.WEB.Model;
using Projeto.WEB.Service.Interface;
using System.Net.Http.Json;
using System.Text.Json;

namespace Projeto.WEB.Service
{
    public class ArquivoService : IArquivoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _serializerOptions;
        private const string? apiEndPoint = "api/Arquivo";
        private readonly ArquivoInputDto arquivoInputDto = new();
        private readonly ArquivoOutputDto arquivoOutputDto = new();
        private readonly ArquivoOutputView arquivoOutputView = new();

        public ArquivoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<ArquivoInputDto> Atualizar(ArquivoInputDto arquivoInputDto)
        {
            throw new NotImplementedException();
        }

        public Task<ArquivoInputDto> Cadastrar(ArquivoInputDto arquivoInputDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArquivoOutputDto> PegarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ArquivoOutputView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "")
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("ConexaoApi");

                var arquivoOutputView = await httpClient.GetFromJsonAsync<ArquivoOutputView>(apiEndPoint + $"?pagina={pagina}&tamanho={tamanho}&pesquisa={pesquisa}");

                if (arquivoOutputView is not null)
                {
                    return arquivoOutputView;
                }
                return new ArquivoOutputView();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ArquivoOutputView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "")
        {
            throw new NotImplementedException();
        }
    }
}
