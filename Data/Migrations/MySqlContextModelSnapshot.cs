﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.BairroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Bairro", (string)null);
                });

            modelBuilder.Entity("Domain.Models.BairrosPoloModel", b =>
                {
                    b.Property<int>("PoloId")
                        .HasColumnType("int")
                        .HasColumnName("poloId");

                    b.Property<int>("BairroId")
                        .HasColumnType("int")
                        .HasColumnName("bairroId");

                    b.HasKey("PoloId", "BairroId");

                    b.HasIndex("BairroId");

                    b.ToTable("BairrosPolo", (string)null);
                });

            modelBuilder.Entity("Domain.Models.ImmobileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Address");

                    b.Property<int>("BairroId")
                        .HasColumnType("int")
                        .HasColumnName("bairroId");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("varchar(3000)")
                        .HasColumnName("Desc");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("externalId");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("json")
                        .HasColumnName("Images");

                    b.Property<ulong>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("in_use");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Map");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("site_url");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Title");

                    b.Property<DateTime>("WebScrappingDate")
                        .HasColumnType("datetime")
                        .HasColumnName("webscraping_date");

                    b.HasKey("Id");

                    b.HasIndex("BairroId");

                    b.ToTable("Immobile", (string)null);
                });

            modelBuilder.Entity("Domain.Models.PoloModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Polo", (string)null);
                });

            modelBuilder.Entity("Domain.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("CellPhone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Email");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.HasAlternateKey("CellPhone")
                        .HasName("AlternateKey_CellPhone");

                    b.HasAlternateKey("Email")
                        .HasName("AlternateKey_Email");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Models.UserPreferenceModel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.Property<int>("ImmobileId")
                        .HasColumnType("int")
                        .HasColumnName("immobileId");

                    b.HasKey("UserId", "ImmobileId");

                    b.HasIndex("ImmobileId");

                    b.ToTable("UserPreference", (string)null);
                });

            modelBuilder.Entity("Domain.Models.BairrosPoloModel", b =>
                {
                    b.HasOne("Domain.Models.BairroModel", "Bairro")
                        .WithMany("BairrosPolo")
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.PoloModel", "Polo")
                        .WithMany("BairrosPolo")
                        .HasForeignKey("PoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bairro");

                    b.Navigation("Polo");
                });

            modelBuilder.Entity("Domain.Models.ImmobileModel", b =>
                {
                    b.HasOne("Domain.Models.BairroModel", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bairro");
                });

            modelBuilder.Entity("Domain.Models.UserPreferenceModel", b =>
                {
                    b.HasOne("Domain.Models.ImmobileModel", "Immobile")
                        .WithMany("UserPreferences")
                        .HasForeignKey("ImmobileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.UserModel", "User")
                        .WithMany("UserPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Immobile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.BairroModel", b =>
                {
                    b.Navigation("BairrosPolo");
                });

            modelBuilder.Entity("Domain.Models.ImmobileModel", b =>
                {
                    b.Navigation("UserPreferences");
                });

            modelBuilder.Entity("Domain.Models.PoloModel", b =>
                {
                    b.Navigation("BairrosPolo");
                });

            modelBuilder.Entity("Domain.Models.UserModel", b =>
                {
                    b.Navigation("UserPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}
