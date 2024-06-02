﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScreenTemperature;

#nullable disable

namespace ScreenTemperature.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ConfigurationProfile", b =>
                {
                    b.Property<Guid>("ConfigurationsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProfilesId")
                        .HasColumnType("TEXT");

                    b.HasKey("ConfigurationsId", "ProfilesId");

                    b.HasIndex("ProfilesId");

                    b.ToTable("ConfigurationProfile");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Configurations.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ApplyBrightness")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Brightness")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DevicePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Configurations");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ScreenTemperature.Entities.KeyBinding", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Alt")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Control")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KeyCode")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Shift")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("KeyBindings");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.KeyBindingActions.KeyBindingAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("KeyBindingId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KeyBindingId");

                    b.ToTable("KeyBindingActions");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Configurations.ColorConfiguration", b =>
                {
                    b.HasBaseType("ScreenTemperature.Entities.Configurations.Configuration");

                    b.Property<bool>("ApplyColor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("ColorConfigurations");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Configurations.TemperatureConfiguration", b =>
                {
                    b.HasBaseType("ScreenTemperature.Entities.Configurations.Configuration");

                    b.Property<bool>("ApplyIntensity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intensity")
                        .HasColumnType("INTEGER");

                    b.ToTable("TemperatureConfigurations");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.KeyBindingActions.ApplyProfileAction", b =>
                {
                    b.HasBaseType("ScreenTemperature.Entities.KeyBindingActions.KeyBindingAction");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("TEXT");

                    b.HasIndex("ProfileId");

                    b.ToTable("ApplyProfileActions");
                });

            modelBuilder.Entity("ConfigurationProfile", b =>
                {
                    b.HasOne("ScreenTemperature.Entities.Configurations.Configuration", null)
                        .WithMany()
                        .HasForeignKey("ConfigurationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScreenTemperature.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScreenTemperature.Entities.KeyBindingActions.KeyBindingAction", b =>
                {
                    b.HasOne("ScreenTemperature.Entities.KeyBinding", "KeyBinding")
                        .WithMany("Actions")
                        .HasForeignKey("KeyBindingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KeyBinding");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Configurations.ColorConfiguration", b =>
                {
                    b.HasOne("ScreenTemperature.Entities.Configurations.Configuration", null)
                        .WithOne()
                        .HasForeignKey("ScreenTemperature.Entities.Configurations.ColorConfiguration", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Configurations.TemperatureConfiguration", b =>
                {
                    b.HasOne("ScreenTemperature.Entities.Configurations.Configuration", null)
                        .WithOne()
                        .HasForeignKey("ScreenTemperature.Entities.Configurations.TemperatureConfiguration", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScreenTemperature.Entities.KeyBindingActions.ApplyProfileAction", b =>
                {
                    b.HasOne("ScreenTemperature.Entities.KeyBindingActions.KeyBindingAction", null)
                        .WithOne()
                        .HasForeignKey("ScreenTemperature.Entities.KeyBindingActions.ApplyProfileAction", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScreenTemperature.Entities.Profile", "Profile")
                        .WithMany("ApplyProfileActions")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.KeyBinding", b =>
                {
                    b.Navigation("Actions");
                });

            modelBuilder.Entity("ScreenTemperature.Entities.Profile", b =>
                {
                    b.Navigation("ApplyProfileActions");
                });
#pragma warning restore 612, 618
        }
    }
}
