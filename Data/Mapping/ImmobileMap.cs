using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Data.Mapping
{
    public class ImmobileMap : IEntityTypeConfiguration<ImmobileModel>
    {
        public void Configure(EntityTypeBuilder<ImmobileModel> builder)
        {
            builder.ToTable("Immobile");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Title)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("varchar(100)");
           
            builder.Property(prop => prop.Address)
              .HasConversion(prop => prop.ToString(), prop => prop)
              .IsRequired()
              .HasColumnName("Address")
              .HasColumnType("varchar(300)");

            builder.Property(prop => prop.Desc)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Desc")
                .HasColumnType("varchar(300)");

            builder.Property(prop => prop.Map)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Map")
               .HasColumnType("varchar(300)");


            builder.Property(prop => prop.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("decimal(10,2)");

            builder.Property(prop => prop.Images)
               .HasConversion(prop => JsonSerializer.Serialize(prop, new JsonSerializerOptions { WriteIndented = true }), prop => prop)
              .IsRequired()
              .HasColumnName("Images")
              .HasColumnType("json");

        }
    }
}
