using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class UserPreferenceMap : IEntityTypeConfiguration<UserPreferenceModel>
    {
        public void Configure(EntityTypeBuilder<UserPreferenceModel> builder)
        {
            builder.ToTable("UserPreference");

            builder.HasKey(u => new {u.UserId , u.ImmobileId });
            builder.Property(u => u.UserId)
                .IsRequired()
                .HasColumnName("userId");
            builder.Property(u => u.ImmobileId)
                .IsRequired()
                .HasColumnName("immobileId");


            builder.HasOne(u => u.User)
                 .WithMany(up => up.UserPreferences)
                 .HasForeignKey(u => u.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Immobile)
                .WithMany(up => up.UserPreferences)
                .HasForeignKey(u => u.ImmobileId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
