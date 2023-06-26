﻿// <auto-generated />
using System;
using MicroBroker.Playlist.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroBroker.Playlist.Infraestructure.Migrations
{
    [DbContext(typeof(PlaylistDbContext))]
    partial class PlaylistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MicroBroker.Playlist.Domain.Models.Playlist", b =>
                {
                    b.Property<int>("Id_Playlist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Playlist"), 1L, 1);

                    b.Property<DateTime?>("Creation_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id_Playlist");

                    b.ToTable("Tbl_Playlist");
                });
#pragma warning restore 612, 618
        }
    }
}