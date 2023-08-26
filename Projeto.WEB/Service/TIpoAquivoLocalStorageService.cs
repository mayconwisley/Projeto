using Blazored.LocalStorage;
using Projeto.WEB.Model;
using Projeto.WEB.Service.Interface;

namespace Projeto.WEB.Service
{
    public class TipoAquivoLocalStorageService : ITipoAquivoLocalStorageService
    {
        private const string key = "TipoArquivoColecao";

        private readonly ILocalStorageService _localStorageService;
        private readonly ITipoArquivoService _tipoArquivoService;

        public TipoAquivoLocalStorageService(ILocalStorageService localStorageService, ITipoArquivoService tipoArquivoService)
        {
            _localStorageService = localStorageService;
            _tipoArquivoService = tipoArquivoService;
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
            var tipoArquivoColecao = await _tipoArquivoService.PegarTodos();
           

            if (tipoArquivoColecao is not null)
            {
                await _localStorageService.SetItemAsync(key, tipoArquivoColecao);
            }
            return tipoArquivoColecao;
        }
    }
}
