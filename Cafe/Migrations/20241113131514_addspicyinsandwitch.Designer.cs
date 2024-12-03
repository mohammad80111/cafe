﻿// <auto-generated />
using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cafe.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241113131514_addspicyinsandwitch")]
    partial class addspicyinsandwitch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cafe.Models.CafeProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SizeId");

                    b.ToTable("CafeProducts");
                });

            modelBuilder.Entity("Cafe.Models.Sandwitch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SpicyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpicyId");

                    b.ToTable("Sandswitches");
                });

            modelBuilder.Entity("Cafe.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Meduim"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Big"
                        });
                });

            modelBuilder.Entity("Cafe.Models.Spicy", b =>
                {
                    b.Property<int>("SpicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpicyId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpicyId");

                    b.ToTable("Spicys");

                    b.HasData(
                        new
                        {
                            SpicyId = 1,
                            Name = "hot"
                        },
                        new
                        {
                            SpicyId = 2,
                            Name = "normal"
                        });
                });

            modelBuilder.Entity("Cafe.Models.CafeProduct", b =>
                {
                    b.HasOne("Cafe.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Cafe.Models.Sandwitch", b =>
                {
                    b.HasOne("Cafe.Models.Spicy", "Spicy")
                        .WithMany()
                        .HasForeignKey("SpicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spicy");
                });
#pragma warning restore 612, 618
        }
    }
}
