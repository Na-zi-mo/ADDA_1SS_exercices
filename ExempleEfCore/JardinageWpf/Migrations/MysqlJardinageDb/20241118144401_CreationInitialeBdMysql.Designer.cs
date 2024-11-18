﻿// <auto-generated />
using JardinageWpf.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JardinageWpf.Migrations.MysqlJardinageDb
{
    [DbContext(typeof(MysqlJardinageDbContext))]
    [Migration("20241118144401_CreationInitialeBdMysql")]
    partial class CreationInitialeBdMysql
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("JardinageWpf.Models.Famille", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Nom")
                        .IsUnique();

                    b.ToTable("Familles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Graminé"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Orchidé"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Labié"
                        });
                });

            modelBuilder.Entity("JardinageWpf.Models.Plante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FamilleId")
                        .HasColumnType("int");

                    b.Property<double>("Hauteur")
                        .HasColumnType("double");

                    b.Property<string>("NomCommun")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomScientifique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FamilleId");

                    b.ToTable("Plantes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FamilleId = 1,
                            Hauteur = 20.0,
                            NomCommun = "Pissenlit",
                            NomScientifique = "Taraxacum officinale F.H. Wigg."
                        },
                        new
                        {
                            Id = 2,
                            FamilleId = 1,
                            Hauteur = 50.0,
                            NomCommun = "Blé",
                            NomScientifique = "Triticum turgidum ssp. durum"
                        },
                        new
                        {
                            Id = 3,
                            FamilleId = 2,
                            Hauteur = 20.0,
                            NomCommun = "Orchidée papillon",
                            NomScientifique = "Phalaenopsis"
                        });
                });

            modelBuilder.Entity("JardinageWpf.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Désertique"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Aride"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Tempéré"
                        });
                });

            modelBuilder.Entity("PlanteRegion", b =>
                {
                    b.Property<int>("PlantesId")
                        .HasColumnType("int");

                    b.Property<int>("RegionsId")
                        .HasColumnType("int");

                    b.HasKey("PlantesId", "RegionsId");

                    b.HasIndex("RegionsId");

                    b.ToTable("PlanteRegion");

                    b.HasData(
                        new
                        {
                            PlantesId = 1,
                            RegionsId = 1
                        },
                        new
                        {
                            PlantesId = 1,
                            RegionsId = 3
                        },
                        new
                        {
                            PlantesId = 2,
                            RegionsId = 2
                        },
                        new
                        {
                            PlantesId = 3,
                            RegionsId = 1
                        });
                });

            modelBuilder.Entity("JardinageWpf.Models.Plante", b =>
                {
                    b.HasOne("JardinageWpf.Models.Famille", "Famille")
                        .WithMany()
                        .HasForeignKey("FamilleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Famille");
                });

            modelBuilder.Entity("PlanteRegion", b =>
                {
                    b.HasOne("JardinageWpf.Models.Plante", null)
                        .WithMany()
                        .HasForeignKey("PlantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JardinageWpf.Models.Region", null)
                        .WithMany()
                        .HasForeignKey("RegionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
