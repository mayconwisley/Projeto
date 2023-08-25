using Blazored.LocalStorage;
using Projeto.WEB.Model;
using Projeto.WEB.Service.Interface;

namespace Projeto.WEB.Service
{
    public class TIpoAquivoLocalStorageService : ITIpoAquivoLocalStorageServices
    {
        private const string key = "TipoArquivoColecao";

        private readonly ILocalStorageService _localStorageService;
        private readonly ITipoArquivoServices _tipoArquivoServices;

        public TIpoAquivoLocalStorageService(ILocalStorageService localStorageService, ITipoArquivoServices tipoArquivoServices)
        {
            _localStorageService = localStorageService;
            _tipoArquivoServices = tipoArquivoServices;
        }

        public async Task<TipoArquivoView> PegarTiposArquivosStorage()
        {
            return await _localStorageService.GetItemAsync<TipoArquivoView>(key) ?? await AdicionarColecao();
        }

        public async Task RemoverColecao()
        {
            await _localStorageService.RemoveItemAsync(key);
        }

        private async Task<TipoArquivoView> AdicionarColecao()
        {
            var tipoArquivoColecao = await _tipoArquivoServices.PegarTodos();

            if (tipoArquivoColecao is not null)
            {
                await _localStorageService.SetItemAsync(key, tipoArquivoColecao);
            }
            return tipoArquivoColecao;
        }
    }
}
