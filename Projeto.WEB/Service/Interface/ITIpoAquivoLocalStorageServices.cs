using Projeto.WEB.Model;

namespace Projeto.WEB.Service.Interface;

public interface ITIpoAquivoLocalStorageServices
{
    Task<TipoArquivoView> PegarTiposArquivosStorage();
    Task RemoverColecao();
}
