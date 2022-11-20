using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Data.Mapping
{
    public class PoloMap : IEntityTypeConfiguration<PoloModel>
    {
        public void Configure(EntityTypeBuilder<PoloModel> builder)
        {
            builder.ToTable("Polo");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");
        }
    }
}
