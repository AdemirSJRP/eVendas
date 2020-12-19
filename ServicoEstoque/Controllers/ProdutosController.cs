using eVendas.Domain.Core.Entities;
using System;

namespace eVendas.ServicoEstoque.Controllers
{
    public class ProdutosController : GenericController<Guid, Produto, Produto>
    {
        public ProdutosController(IServiceProvider serviceProvider) : base(serviceProvider) { }


    }
}
