using Projeto.WEB.Model;

namespace Projeto.WEB.Service.Interface;

public interface ITipoAquivoLocalStorageService
{
    Task<TipoArquivoView> PegarTiposArquivosStorage();
    Task RemoverColecao();
}
