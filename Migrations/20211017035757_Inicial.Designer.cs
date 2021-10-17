﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registro_Con_Detalle.DAL;

namespace Registro_Con_Detalle.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211017035757_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Registro_Con_Detalle.Entidades.Permisos", b =>
                {
                    b.Property<int>("PermisoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("VecesAsignado")
                        .HasColumnType("INTEGER");

                    b.HasKey("PermisoID");

                    b.ToTable("Permisos");

                    b.HasData(
                        new
                        {
                            PermisoID = 1,
                            Descripcion = "Area Ciberseguridad",
                            Nombre = "Pedro Solorin",
                            VecesAsignado = 0
                        },
                        new
                        {
                            PermisoID = 2,
                            Descripcion = "Administrador",
                            Nombre = "Carlos Herrera",
                            VecesAsignado = 0
                        });
                });

            modelBuilder.Entity("Registro_Con_Detalle.Entidades.Roles", b =>
                {
                    b.Property<int>("RoiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EsActivo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.HasKey("RoiID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Registro_Con_Detalle.Entidades.RolesDetalle", b =>
                {
                    b.Property<int>("RolesDetalleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EsAsignado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermisoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoiID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolesDetalleID");

                    b.HasIndex("PermisoID");

                    b.HasIndex("RoiID");

                    b.ToTable("RolesDetalle");
                });

            modelBuilder.Entity("Registro_Con_Detalle.Entidades.RolesDetalle", b =>
                {
                    b.HasOne("Registro_Con_Detalle.Entidades.Permisos", null)
                        .WithMany("RolesDetalle")
                        .HasForeignKey("PermisoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Registro_Con_Detalle.Entidades.Roles", null)
                        .WithMany("RolesDetalle")
                        .HasForeignKey("RoiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Registro_Con_Detalle.Entidades.Permisos", b =>
                {
                    b.Navigation("RolesDetalle");
                });

            modelBuilder.Entity("Registro_Con_Detalle.Entidades.Roles", b =>
                {
                    b.Navigation("RolesDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
