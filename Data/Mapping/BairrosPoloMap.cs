using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Mapping
{
    public class BairrosPoloMap : IEntityTypeConfiguration<BairrosPoloModel>
    {
        public void Configure(EntityTypeBuilder<BairrosPoloModel> builder)
        {
            builder.ToTable("BairrosPolo");

            builder.HasKey(u => new { u.PoloId, u.BairroId });
            builder.Property(u => u.PoloId)
                .IsRequired()
                .HasColumnName("poloId");
            builder.Property(u => u.BairroId)
                .IsRequired()
                .HasColumnName("bairroId");


            builder.HasOne(u => u.Polo)
                 .WithMany(up => up.BairrosPolo)
                 .HasForeignKey(u => u.PoloId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Bairro)
                .WithMany(up => up.BairrosPolo)
                .HasForeignKey(u => u.BairroId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
