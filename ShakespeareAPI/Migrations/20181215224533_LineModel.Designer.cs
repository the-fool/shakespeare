﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181215224533_LineModel")]
    partial class LineModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ShakespeareAPI.Models.Line", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActNumber");

                    b.Property<string>("Character");

                    b.Property<int>("CharacterLineNumber");

                    b.Property<int>("LineNumber");

                    b.Property<int>("PlayID");

                    b.Property<int>("SceneNumber");

                    b.Property<string>("Text");

                    b.HasKey("LineID");

                    b.HasIndex("PlayID");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Play", b =>
                {
                    b.Property<int>("PlayID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Genre");

                    b.Property<string>("Name");

                    b.HasKey("PlayID");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("ShakespeareAPI.Models.Line", b =>
                {
                    b.HasOne("ShakespeareAPI.Models.Play", "Play")
                        .WithMany()
                        .HasForeignKey("PlayID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}