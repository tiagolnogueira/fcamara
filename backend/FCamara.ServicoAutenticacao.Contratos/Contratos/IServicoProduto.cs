using FCamara.Servicos.Contratos.Dto;
using System.Collections.Generic;

namespace FCamara.Servicos.Contratos
{
    public interface IServicoProduto
    {
        IList<ProdutoDto> ListarProdutos();
    }
}
