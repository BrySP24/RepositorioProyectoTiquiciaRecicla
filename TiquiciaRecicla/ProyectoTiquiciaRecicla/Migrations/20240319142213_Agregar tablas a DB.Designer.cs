﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoTiquiciaRecicla.Data;

#nullable disable

namespace ProyectoTiquiciaRecicla.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240319142213_Agregar tablas a DB")]
    partial class AgregartablasaDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_Empresa_RecolectoraId")
                        .HasColumnType("int");

                    b.Property<string>("CH_Correo_Electronico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Horario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Telefono")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<double>("DEC_Latitud")
                        .HasColumnType("float");

                    b.Property<double>("DEC_Longitud")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CAT_Empresa_RecolectoraId");

                    b.ToTable("CAT_Centros_De_Acopio");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Centro_Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_Centro_De_AcopioId")
                        .HasColumnType("int");

                    b.Property<int>("CAT_Tipo_De_MaterialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CAT_Centro_De_AcopioId");

                    b.HasIndex("CAT_Tipo_De_MaterialId");

                    b.ToTable("CAT_Centros_Materiales");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Empresa_Recolectora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CH_Correo_Electronico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Horario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Telefono")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<double>("DEC_Latitud")
                        .HasColumnType("float");

                    b.Property<double>("DEC_Longitud")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CAT_Empresas_Recolectoras");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CH_Nombre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("CAT_Provincias");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Tipo_De_Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CH_Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CH_Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Tratamiento")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("CAT_Tipos_De_Materiales");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_Centro_De_AcopioId")
                        .HasColumnType("int");

                    b.Property<string>("CH_Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CH_Titulo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("IMG_Banner")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("CAT_Centro_De_AcopioId");

                    b.ToTable("TBL_Anuncios");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_Empresa_RecolectoraId")
                        .HasColumnType("int");

                    b.Property<string>("CH_Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CH_Nombre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CH_Premio")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DTI_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DTI_Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CAT_Empresa_RecolectoraId");

                    b.ToTable("TBL_Eventos");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Historico_Sesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DIT_Fecha_Hora_Cierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DTI_Fecha_Hora_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("TBL_UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TBL_UsuarioId");

                    b.ToTable("TBL_Historicos_Sesiones");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Recibo_De_Reciclaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_Centro_De_AcopioId")
                        .HasColumnType("int");

                    b.Property<int>("CAT_Tipo_De_MaterialId")
                        .HasColumnType("int");

                    b.Property<float>("DEC_Peso")
                        .HasColumnType("real");

                    b.Property<DateTime>("DTI_Fecha_Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("TBL_UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CAT_Centro_De_AcopioId");

                    b.HasIndex("CAT_Tipo_De_MaterialId");

                    b.HasIndex("TBL_UsuarioId");

                    b.ToTable("TBL_Recibos_De_Reciclaje");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_ProvinciaId")
                        .HasColumnType("int");

                    b.Property<string>("CH_Apellido_1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Clave")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CH_Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CH_Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Telefono")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CH_apellido_2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CAT_ProvinciaId");

                    b.ToTable("TBL_Usuarios");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Zona_de_Recolecta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CAT_Centro_De_AcopioId")
                        .HasColumnType("int");

                    b.Property<string>("CH_Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CH_Horario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("DEC_Latitud")
                        .HasColumnType("float");

                    b.Property<double>("DEC_Longitud")
                        .HasColumnType("float");

                    b.Property<DateTime>("DTI_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DTI_Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CAT_Centro_De_AcopioId");

                    b.ToTable("TBL_Zonas_de_Recolecta");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Empresa_Recolectora", "CAT_Empresas_Recolectoras")
                        .WithMany("CAT_Centros_De_Acopios")
                        .HasForeignKey("CAT_Empresa_RecolectoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Empresas_Recolectoras");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Centro_Material", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", "CAT_Centros_De_Acopio")
                        .WithMany()
                        .HasForeignKey("CAT_Centro_De_AcopioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Tipo_De_Material", "CAT_Tipos_De_Materiales")
                        .WithMany()
                        .HasForeignKey("CAT_Tipo_De_MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Centros_De_Acopio");

                    b.Navigation("CAT_Tipos_De_Materiales");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Anuncio", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", "CAT_Centros_De_Acopio")
                        .WithMany("TBL_Anuncios")
                        .HasForeignKey("CAT_Centro_De_AcopioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Centros_De_Acopio");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Evento", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Empresa_Recolectora", "CAT_Empresas_Recolectoras")
                        .WithMany()
                        .HasForeignKey("CAT_Empresa_RecolectoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Empresas_Recolectoras");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Historico_Sesion", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.TBL_Usuario", "TBL_Usuarios")
                        .WithMany()
                        .HasForeignKey("TBL_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TBL_Usuarios");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Recibo_De_Reciclaje", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", "CAT_Centros_De_Acopio")
                        .WithMany()
                        .HasForeignKey("CAT_Centro_De_AcopioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Tipo_De_Material", "CAT_Tipos_De_Materiales")
                        .WithMany()
                        .HasForeignKey("CAT_Tipo_De_MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoTiquiciaRecicla.Models.TBL_Usuario", "TBL_Usuarios")
                        .WithMany()
                        .HasForeignKey("TBL_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Centros_De_Acopio");

                    b.Navigation("CAT_Tipos_De_Materiales");

                    b.Navigation("TBL_Usuarios");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Usuario", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Provincia", "CAT_Provincias")
                        .WithMany("TBL_Usuarios")
                        .HasForeignKey("CAT_ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Provincias");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.TBL_Zona_de_Recolecta", b =>
                {
                    b.HasOne("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", "CAT_Centros_De_Acopio")
                        .WithMany("TBL_Zonas_de_Recolectas")
                        .HasForeignKey("CAT_Centro_De_AcopioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAT_Centros_De_Acopio");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Centro_De_Acopio", b =>
                {
                    b.Navigation("TBL_Anuncios");

                    b.Navigation("TBL_Zonas_de_Recolectas");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Empresa_Recolectora", b =>
                {
                    b.Navigation("CAT_Centros_De_Acopios");
                });

            modelBuilder.Entity("ProyectoTiquiciaRecicla.Models.CAT_Provincia", b =>
                {
                    b.Navigation("TBL_Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
