﻿// <auto-generated />
using System;
using MantenedoresPerfilCliente.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MantenedoresPerfilCliente.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180822202424_Precarga")]
    partial class Precarga
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_ARA");

                    b.HasData(
                        new { Id = 1, Nombre = "Admision Riesgo" },
                        new { Id = 2, Nombre = "Desarrollo Comercial" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_CRG");

                    b.HasData(
                        new { Id = 1, Descripcion = "Ejecutivo Comercial" },
                        new { Id = 2, Descripcion = "Agente Comercial" },
                        new { Id = 3, Descripcion = "Analista de Riesgo" },
                        new { Id = 4, Descripcion = "Jefe Deto." },
                        new { Id = 5, Descripcion = "Gerente de Riesgo" },
                        new { Id = 6, Descripcion = "Otro" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.EstadoFiltro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_EFT");

                    b.HasData(
                        new { Id = 1, Cod = "A", Descripcion = "Activo" },
                        new { Id = 2, Cod = "N", Descripcion = "Inactivo" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.EstadoPerfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_EPF");

                    b.HasData(
                        new { Id = 1, Cod = "A", Descripcion = "Activo" },
                        new { Id = 2, Cod = "N", Descripcion = "Inactivo" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Exclusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId");

                    b.Property<int>("CargoId");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("Fechainicio");

                    b.Property<int>("MotivoBloqueoId");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CargoId");

                    b.HasIndex("MotivoBloqueoId");

                    b.ToTable("TBL_PRF_MNT_EXC");
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Filtro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<int?>("Corte1");

                    b.Property<int?>("Corte2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("EstadoFiltroId");

                    b.Property<double?>("Monto1");

                    b.Property<double?>("Monto2");

                    b.Property<int>("Orden");

                    b.Property<int>("PerfilId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoFiltroId");

                    b.HasIndex("Orden")
                        .IsUnique();

                    b.HasIndex("PerfilId");

                    b.ToTable("TBL_PRF_MNT_FTS");
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.MotivoBloqueo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TipoBloqueo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_MVB");

                    b.HasData(
                        new { Id = 1, Descripcion = "Fraude(Titular-Relacionado)", TipoBloqueo = "Permanente" },
                        new { Id = 2, Descripcion = "Suficientemente atendido", TipoBloqueo = "Temporal" },
                        new { Id = 3, Descripcion = "Sector Economico", TipoBloqueo = "Temporal" },
                        new { Id = 4, Descripcion = "Cliente no desea recibir Ofertas", TipoBloqueo = "Temporal" },
                        new { Id = 5, Descripcion = "Bloqueo Duro de Riesgo", TipoBloqueo = "Permanente" },
                        new { Id = 6, Descripcion = "Bloqueo Comercial", TipoBloqueo = "Permanente" },
                        new { Id = 7, Descripcion = "Bloqueo 1", TipoBloqueo = "Temporal" },
                        new { Id = 8, Descripcion = "Bloqueo 2", TipoBloqueo = "Temporal" },
                        new { Id = 9, Descripcion = "Bloqueo 3", TipoBloqueo = "Temporal" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<int>("EstadoPerfilId");

                    b.Property<double?>("PiMax");

                    b.Property<int>("TipoPerfilId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoPerfilId");

                    b.HasIndex("TipoPerfilId");

                    b.ToTable("TBL_PRF_MNT_PFS");
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.TipoPerfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_TPF");

                    b.HasData(
                        new { Id = 1, Cod = "F", Descripcion = "Filtro" },
                        new { Id = 2, Cod = "F", Descripcion = "Filtro" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Universo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cod")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PRF_MNT_UNV");

                    b.HasData(
                        new { Id = 1, Cod = "C", Descripcion = "Cliente" },
                        new { Id = 2, Cod = "N", Descripcion = "No Cliente" },
                        new { Id = 3, Cod = "A", Descripcion = "Ambos" }
                    );
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Exclusion", b =>
                {
                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.MotivoBloqueo", "MotivoBloqueo")
                        .WithMany()
                        .HasForeignKey("MotivoBloqueoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Filtro", b =>
                {
                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.EstadoFiltro", "EstadoFiltro")
                        .WithMany()
                        .HasForeignKey("EstadoFiltroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MantenedoresPerfilCliente.Domain.Entities.Perfil", b =>
                {
                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.EstadoPerfil", "EstadoPerfil")
                        .WithMany()
                        .HasForeignKey("EstadoPerfilId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MantenedoresPerfilCliente.Domain.Entities.TipoPerfil", "TipoPerfil")
                        .WithMany()
                        .HasForeignKey("TipoPerfilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
