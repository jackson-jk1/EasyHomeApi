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
    public class ContactsMap : IEntityTypeConfiguration<ContactsModel>
    {
        public void Configure(EntityTypeBuilder<ContactsModel> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(u => new {u.UserId , u.ContactId });
            builder.Property(u => u.UserId)
                .IsRequired()
                .HasColumnName("userId");
            builder.Property(u => u.ContactId)
                .IsRequired()
                .HasColumnName("contactId");


            builder.HasOne(u => u.User)
                 .WithMany(up => up.Contacts)
                 .HasForeignKey(u => u.ContactId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.User)
                 .WithMany(up => up.Contacts)
                 .HasForeignKey(u => u.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
