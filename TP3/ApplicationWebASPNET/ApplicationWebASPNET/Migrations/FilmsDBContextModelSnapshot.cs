﻿// <auto-generated />
using System;
using ApplicationWebASPNET.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApplicationWebASPNET.Migrations
{
    [DbContext(typeof(FilmsDBContext))]
    partial class FilmsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ApplicationWebASPNET.Models.EntityFramework.Compte", b =>
                {
                    b.Property<int>("CompteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnName("CPT_CP")
                        .HasColumnType("char(5)");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_DATECREATION")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2020, 9, 29, 21, 39, 40, 726, DateTimeKind.Local).AddTicks(6466));

                    b.Property<float?>("Latitude")
                        .HasColumnName("CPT_LATITUDE")
                        .HasColumnType("real");

                    b.Property<float?>("Longitude")
                        .HasColumnName("CPT_LONGITUDE")
                        .HasColumnType("real");

                    b.Property<string>("Mel")
                        .IsRequired()
                        .HasColumnName("CPT_MEL")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("CPT_NOM")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Pays")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_PAYS")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("France");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnName("CPT_PRENOM")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Pwd")
                        .HasColumnName("CPT_PWD")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnName("CPT_RUE")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TelPortable")
                        .HasColumnName("CPT_TELPORTABLE")
                        .HasColumnType("char(10)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnName("CPT_VILLE")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("CompteId");

                    b.HasIndex("Mel")
                        .IsUnique();

                    b.ToTable("T_E_COMPTE_CPT");
                });

            modelBuilder.Entity("ApplicationWebASPNET.Models.EntityFramework.Favori", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnName("FLM_ID")
                        .HasColumnType("integer");

                    b.Property<int>("CompteId")
                        .HasColumnName("CPT_ID")
                        .HasColumnType("integer");

                    b.HasKey("FilmId", "CompteId")
                        .HasName("PK_FAV");

                    b.HasIndex("CompteId");

                    b.ToTable("T_J_FAVORI_FAV");
                });

            modelBuilder.Entity("ApplicationWebASPNET.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FLM_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateParution")
                        .HasColumnName("FLM_DATEPARUTION")
                        .HasColumnType("timestamp without time zone")
                        .HasMaxLength(500);

                    b.Property<decimal>("Duree")
                        .HasColumnName("FLM_DUREE")
                        .HasColumnType("numeric")
                        .HasMaxLength(500);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnName("FLM_GENRE")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Synopsis")
                        .HasColumnName("FLM_SYNOPSIS")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnName("FLM_TITRE")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UrlPhoto")
                        .HasColumnName("FLM_URLPHOTO")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("FilmId");

                    b.ToTable("T_E_FILM_FLM");
                });

            modelBuilder.Entity("ApplicationWebASPNET.Models.EntityFramework.Favori", b =>
                {
                    b.HasOne("ApplicationWebASPNET.Models.EntityFramework.Compte", "CompteFavori")
                        .WithMany("Favoris")
                        .HasForeignKey("CompteId")
                        .HasConstraintName("FK_FAV_COM")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApplicationWebASPNET.Models.EntityFramework.Film", "FilmFavori")
                        .WithMany("Favoris")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_FAV_FLM")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
