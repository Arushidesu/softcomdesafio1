﻿// <auto-generated />
using System;
using JsonParse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JsonParse.Migrations
{
    [DbContext(typeof(ContasDbContext))]
    partial class ContasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("JsonParse.Models.Conta", b =>
                {
                    b.Property<int>("ContaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Resumo");

                    b.Property<string>("Titulo");

                    b.Property<int>("UsuarioId");

                    b.Property<double>("Valor");

                    b.Property<DateTime>("Vencimento");

                    b.HasKey("ContaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Conta");

                    b.HasData(
                        new
                        {
                            ContaId = 1,
                            Resumo = "Mensalidade academia",
                            Titulo = "14/25-25",
                            UsuarioId = 1,
                            Valor = 49.990000000000002,
                            Vencimento = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 2,
                            Resumo = "Conta de agua",
                            Titulo = "s/n",
                            UsuarioId = 1,
                            Valor = 84.109999999999999,
                            Vencimento = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 3,
                            Resumo = "Aluguel de carro",
                            Titulo = "52",
                            UsuarioId = 1,
                            Valor = 149.0,
                            Vencimento = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 4,
                            Resumo = "Aluguel de carro",
                            Titulo = "53",
                            UsuarioId = 1,
                            Valor = 149.0,
                            Vencimento = new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 5,
                            Resumo = "Vacinas do cachorro que ficou doente após um passeio na praia",
                            Titulo = "1",
                            UsuarioId = 1,
                            Valor = 32.409999999999997,
                            Vencimento = new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 6,
                            Resumo = "Mensalidade academia",
                            Titulo = "14/26",
                            UsuarioId = 1,
                            Valor = 449.99000000000001,
                            Vencimento = new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 7,
                            Resumo = "Conta de luz",
                            Titulo = "s/n",
                            UsuarioId = 1,
                            Valor = 44.780000000000001,
                            Vencimento = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 8,
                            Resumo = "Aluguel de carro",
                            Titulo = "54",
                            UsuarioId = 1,
                            Valor = 149.0,
                            Vencimento = new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ContaId = 9,
                            Resumo = "Aluguel de carro",
                            Titulo = "55",
                            UsuarioId = 1,
                            Valor = 149.0,
                            Vencimento = new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("JsonParse.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Fone");

                    b.Property<string>("Nome");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Email = "carlos@carlao.com",
                            Fone = "83988472514",
                            Nome = "Carlos Carlão"
                        });
                });

            modelBuilder.Entity("JsonParse.Models.Conta", b =>
                {
                    b.HasOne("JsonParse.Models.Usuario", "Usuario")
                        .WithMany("Contas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
