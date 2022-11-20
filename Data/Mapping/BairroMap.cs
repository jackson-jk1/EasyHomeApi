using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Data.Mapping
{
    public class BairroMap : IEntityTypeConfiguration<BairroModel>
    {
        public void Configure(EntityTypeBuilder<BairroModel> builder)
        {
            builder.ToTable("Bairro");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");
        }
    }
}
