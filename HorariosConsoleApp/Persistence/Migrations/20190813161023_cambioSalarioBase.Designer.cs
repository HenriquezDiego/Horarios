﻿// <auto-generated />
using System;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HorariosConsoleApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190813161023_cambioSalarioBase")]
    partial class cambioSalarioBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorariosConsoleApp.Entities.Dia", b =>
                {
                    b.Property<int>("DiaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura");

                    b.Property<string>("Descripcion");

                    b.HasKey("DiaId");

                    b.ToTable("Dias");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("SalarioBase");

                    b.HasKey("EmpleadoId");

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            EmpleadoId = 1,
                            Apellido = "Perez",
                            Nombre = "Juan",
                            SalarioBase = 0m
                        },
                        new
                        {
                            EmpleadoId = 2,
                            Apellido = "Mitnick",
                            Nombre = "Kevin",
                            SalarioBase = 0m
                        },
                        new
                        {
                            EmpleadoId = 3,
                            Apellido = "Quezada",
                            Nombre = "Jose",
                            SalarioBase = 0m
                        },
                        new
                        {
                            EmpleadoId = 4,
                            Apellido = "Rulfo",
                            Nombre = "Juan",
                            SalarioBase = 0m
                        });
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.EmpleadoEquipo", b =>
                {
                    b.Property<int>("EmpleadoEquipoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<int>("EquipoId");

                    b.HasKey("EmpleadoEquipoId");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("EquipoId");

                    b.ToTable("EmpleadosEquipos");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.Equipo", b =>
                {
                    b.Property<int>("EquipoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<int>("HorarioId");

                    b.HasKey("EquipoId");

                    b.HasIndex("HorarioId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.Hora", b =>
                {
                    b.Property<int>("HoraId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura");

                    b.Property<string>("Descripcion");

                    b.Property<decimal>("PorcetajeExtra");

                    b.HasKey("HoraId");

                    b.ToTable("Horas");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.Horario", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.HasKey("HorarioId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.HorarioDetalle", b =>
                {
                    b.Property<int>("HorarioDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad");

                    b.Property<int>("DiaId");

                    b.Property<int>("HoraId");

                    b.Property<int?>("HorarioId");

                    b.HasKey("HorarioDetalleId");

                    b.HasIndex("DiaId");

                    b.HasIndex("HoraId");

                    b.HasIndex("HorarioId");

                    b.ToTable("HorarioDetalles");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.LogCambios", b =>
                {
                    b.Property<int>("LogCambiosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoId");

                    b.Property<int>("EquipoId");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<int?>("HorarioId");

                    b.HasKey("LogCambiosId");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("EquipoId");

                    b.HasIndex("HorarioId");

                    b.ToTable("LogCambios");
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.EmpleadoEquipo", b =>
                {
                    b.HasOne("HorariosConsoleApp.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorariosConsoleApp.Entities.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.Equipo", b =>
                {
                    b.HasOne("HorariosConsoleApp.Entities.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.HorarioDetalle", b =>
                {
                    b.HasOne("HorariosConsoleApp.Entities.Dia", "Dia")
                        .WithMany()
                        .HasForeignKey("DiaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorariosConsoleApp.Entities.Hora", "Hora")
                        .WithMany()
                        .HasForeignKey("HoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorariosConsoleApp.Entities.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HorariosConsoleApp.Entities.LogCambios", b =>
                {
                    b.HasOne("HorariosConsoleApp.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorariosConsoleApp.Entities.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HorariosConsoleApp.Entities.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}