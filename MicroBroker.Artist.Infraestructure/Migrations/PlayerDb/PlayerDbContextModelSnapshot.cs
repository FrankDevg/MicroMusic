﻿// <auto-generated />
using MicroBroker.Artist.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroBroker.Artist.Data.Migrations.PlayerDb
{
    [DbContext(typeof(PlayerDbContext))]
    partial class PlayerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MicroBroker.Artist.Domain.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("IdArtist")
                        .HasColumnType("int");

                    b.Property<int>("IdSong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
