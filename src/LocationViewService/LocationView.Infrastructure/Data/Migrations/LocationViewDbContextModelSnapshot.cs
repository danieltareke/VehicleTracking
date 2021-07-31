﻿// <auto-generated />
using System;
using LocationView.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocationView.Infrastructure.Data.Migrations
{
    [DbContext(typeof(LocationViewDbContext))]
    partial class LocationViewDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("vts")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LocationView.Core.Domain.DeviceInfo", b =>
                {
                    b.Property<string>("DeviceId")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("device_id");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_time");

                    b.Property<string>("VehiclePlateNo")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("plate_no");

                    b.HasKey("DeviceId");

                    b.ToTable("device_info");
                });

            modelBuilder.Entity("LocationView.Core.Domain.DeviceLocation", b =>
                {
                    b.Property<int>("DeviceLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DeviceId")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("latitude");

                    b.Property<string>("Longitude")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("longitude");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("time_stamp");

                    b.HasKey("DeviceLocationId");

                    b.HasIndex("DeviceId");

                    b.ToTable("device_location");
                });

            modelBuilder.Entity("LocationView.Core.Domain.DeviceLocation", b =>
                {
                    b.HasOne("LocationView.Core.Domain.DeviceInfo", "Device")
                        .WithMany("Locations")
                        .HasForeignKey("DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("LocationView.Core.Domain.DeviceInfo", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
