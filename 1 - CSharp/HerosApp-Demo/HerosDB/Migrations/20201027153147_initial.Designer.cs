﻿// <auto-generated />
using System;
using HerosDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HerosDB.Migrations
{
    [DbContext(typeof(HerosContext))]
    [Migration("20201027153147_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HerosDB.Models.SuperEnemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("SuperHeroId")
                        .HasColumnType("integer");

                    b.Property<int>("SuperVillainId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SuperHeroId");

                    b.HasIndex("SuperVillainId");

                    b.ToTable("SuperEnemy");
                });

            modelBuilder.Entity("HerosDB.Models.SuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("text");

                    b.Property<string>("HideOut")
                        .HasColumnType("text");

                    b.Property<string>("RealName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SuperHeroes");
                });

            modelBuilder.Entity("HerosDB.Models.SuperPower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("SuperHeroId")
                        .HasColumnType("integer");

                    b.Property<int?>("SuperVillainId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SuperHeroId");

                    b.HasIndex("SuperVillainId");

                    b.ToTable("SuperPowers");
                });

            modelBuilder.Entity("HerosDB.Models.SuperVillain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("text");

                    b.Property<string>("HideOut")
                        .HasColumnType("text");

                    b.Property<string>("RealName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SuperVillains");
                });

            modelBuilder.Entity("HerosDB.Models.SuperEnemy", b =>
                {
                    b.HasOne("HerosDB.Models.SuperHero", "SuperHero")
                        .WithMany("Nemesis")
                        .HasForeignKey("SuperHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerosDB.Models.SuperVillain", "SuperVillain")
                        .WithMany("Nemesis")
                        .HasForeignKey("SuperVillainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HerosDB.Models.SuperPower", b =>
                {
                    b.HasOne("HerosDB.Models.SuperHero", null)
                        .WithMany("SuperPowers")
                        .HasForeignKey("SuperHeroId");

                    b.HasOne("HerosDB.Models.SuperVillain", null)
                        .WithMany("SuperPowers")
                        .HasForeignKey("SuperVillainId");
                });
#pragma warning restore 612, 618
        }
    }
}
