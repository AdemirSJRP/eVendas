using System;

namespace eVendas.Domain.Core.Entities
{
    public class Produto : BaseEntity<Guid>
    {
        public new Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Qtidade { get; set; }
    }
}
