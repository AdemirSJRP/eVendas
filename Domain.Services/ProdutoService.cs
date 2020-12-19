using eVendas.Domain.Core.Entities;
using eVendas.Domain.Core.Interfaces.Repositories;
using eVendas.Publisher;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProdutoService : ServiceBaseCrud<Guid, Produto>
    {
        private readonly IPublisher _publisher;

        public ProdutoService(IBaseRepository<Guid, Produto> repository, IPublisher publisher) : base(repository)
        {
            _publisher = publisher;
        }

        public override async Task<Produto> AddAsync(Produto data)
        {
            var produto = await base.AddAsync(data);
            if (produto != null) await _publisher.SendMessageAsync("produtocriado", produto);
            return produto;
        }

        public override async Task<Produto> UpdateAsync(Produto data)
        {

            Produto updated = await UpdateAsync(data);
            if (updated != null) await _publisher.SendMessageAsync("produtoeditado", updated);
            return updated;
        }
    }
}
