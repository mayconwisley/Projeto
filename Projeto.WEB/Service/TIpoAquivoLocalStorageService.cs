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

        public async Task<TipoArquivoView> PegarTiposArquivosStorage(int pagina)
        {
            return await _localStorageService.GetItemAsync<TipoArquivoView>($"{key}-pagina:{pagina}") ?? await AdicionarColecao(pagina);
        }

        public async Task RemoverColecao()
        {
            await _localStorageService.ClearAsync();
            //await _localStorageService.RemoveItemAsync($"{key}-pagina:{pagina}");
        }

        private async Task<TipoArquivoView> AdicionarColecao(int pagina)
        {
            var tipoArquivoColecao = await _tipoArquivoService.PegarTodos(pagina);


            if (tipoArquivoColecao is not null)
            {
                await _localStorageService.SetItemAsync($"{key}-pagina:{pagina}", tipoArquivoColecao);
                return tipoArquivoColecao;
            }
            return new TipoArquivoView();

        }
    }
}
