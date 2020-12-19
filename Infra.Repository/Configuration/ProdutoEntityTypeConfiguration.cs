using eVendas.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eVendas.Infra.Repository.Configuration
{
    class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Preco).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Qtidade).IsRequired().HasDefaultValue(0);
        }

    }
}
