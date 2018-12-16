﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShakespeareAPI;

namespace ShakespeareAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ShakespeareAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cardinality");

                    b.Property<int?>("CharacterId");

                    b.Property<int?>("SceneId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SceneId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Scene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Act");

                    b.Property<string>("Description");

                    b.Property<int>("Order");

                    b.Property<int?>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("Genre");

                    b.Property<string>("LongTitle");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Paragraph", b =>
                {
                    b.HasOne("ShakespeareAPI.Models.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");

                    b.HasOne("ShakespeareAPI.Models.Scene", "Scene")
                        .WithMany()
                        .HasForeignKey("SceneId");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Scene", b =>
                {
                    b.HasOne("ShakespeareAPI.Models.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId");
                });
#pragma warning restore 612, 618
        }
    }
}
