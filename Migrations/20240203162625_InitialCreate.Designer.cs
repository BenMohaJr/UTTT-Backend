﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ultimate_Tic_Tac_Toe.Data;

#nullable disable

namespace Ultimate_Tic_Tac_Toe.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240203162625_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PlayersId")
                        .HasColumnType("integer");

                    b.Property<int>("UserNameLosses")
                        .HasColumnType("integer");

                    b.Property<int>("UserNameWins")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayersId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.LocalBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("BoardIsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("CellX")
                        .HasColumnType("integer");

                    b.Property<int>("CellY")
                        .HasColumnType("integer");

                    b.Property<int?>("MainBoardId")
                        .HasColumnType("integer");

                    b.Property<bool>("TileIsOccupied")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MainBoardId");

                    b.ToTable("LocalBoard");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.MainBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BoardStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("End_Time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("GamesId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start_Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.ToTable("MainBoard");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.Games", b =>
                {
                    b.HasOne("Ultimate_Tic_Tac_Toe.Models.Players", null)
                        .WithMany("GamesID")
                        .HasForeignKey("PlayersId");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.LocalBoard", b =>
                {
                    b.HasOne("Ultimate_Tic_Tac_Toe.Models.MainBoard", null)
                        .WithMany("LocalBoardID")
                        .HasForeignKey("MainBoardId");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.MainBoard", b =>
                {
                    b.HasOne("Ultimate_Tic_Tac_Toe.Models.Games", null)
                        .WithMany("BoardsID")
                        .HasForeignKey("GamesId");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.Games", b =>
                {
                    b.Navigation("BoardsID");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.MainBoard", b =>
                {
                    b.Navigation("LocalBoardID");
                });

            modelBuilder.Entity("Ultimate_Tic_Tac_Toe.Models.Players", b =>
                {
                    b.Navigation("GamesID");
                });
#pragma warning restore 612, 618
        }
    }
}
