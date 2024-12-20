﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using adress_import.Data;

#nullable disable

namespace adress_import.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("adress_import.Data.Adressen", b =>
                {
                    b.Property<int>("AID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AID"));

                    b.Property<int>("FK_FID")
                        .HasColumnType("int");

                    b.Property<int>("FK_OID")
                        .HasColumnType("int");

                    b.Property<int>("Hausnummer")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrtschaftOID")
                        .HasColumnType("int");

                    b.Property<string>("Strasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AID");

                    b.HasIndex("FK_OID");

                    b.HasIndex("OrtschaftOID");

                    b.ToTable("Adressen", (string)null);
                });

            modelBuilder.Entity("adress_import.Data.Firmen", b =>
                {
                    b.Property<int>("FID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FID"));

                    b.Property<string>("Firmenname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FID");

                    b.ToTable("Firmen", (string)null);
                });

            modelBuilder.Entity("adress_import.Data.Ortschaften", b =>
                {
                    b.Property<int>("OID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OID"));

                    b.Property<string>("Ort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Postleitzahl")
                        .HasColumnType("int");

                    b.HasKey("OID");

                    b.ToTable("Ortschaften", (string)null);
                });

            modelBuilder.Entity("adress_import.Data.Adressen", b =>
                {
                    b.HasOne("adress_import.Data.Firmen", "Firma")
                        .WithMany("Adressen")
                        .HasForeignKey("FK_OID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("adress_import.Data.Ortschaften", "Ortschaft")
                        .WithMany("Adressen")
                        .HasForeignKey("OrtschaftOID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");

                    b.Navigation("Ortschaft");
                });

            modelBuilder.Entity("adress_import.Data.Firmen", b =>
                {
                    b.Navigation("Adressen");
                });

            modelBuilder.Entity("adress_import.Data.Ortschaften", b =>
                {
                    b.Navigation("Adressen");
                });
#pragma warning restore 612, 618
        }
    }
}