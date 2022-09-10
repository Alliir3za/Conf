﻿// <auto-generated />
using System;
using ConfSys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfSys.Data.Migrations
{
    [DbContext(typeof(ConfSysDbContext))]
    [Migration("20220907122030_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConfSys.Domain.Entity.FamilyMember", b =>
                {
                    b.Property<int>("FamilyMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyMemberId"), 1L, 1);

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)");

                    b.Property<byte>("Relation")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FamilyMemberId");

                    b.HasIndex("UserId");

                    b.ToTable("FamilyMember", "Base");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Members", b =>
                {
                    b.Property<int>("MembersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembersId"), 1L, 1);

                    b.Property<DateTime>("EndOfEngagement")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Engagement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MembersId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Members", "Base");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Origin", b =>
                {
                    b.Property<int>("OriginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OriginId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("OriginId");

                    b.ToTable("Origin", "Base");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Project", "Base");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("UserId");

                    b.HasIndex("OriginId");

                    b.ToTable("User", "Base");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.FamilyMember", b =>
                {
                    b.HasOne("ConfSys.Domain.Entity.User", "User")
                        .WithMany("FamilyMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Members", b =>
                {
                    b.HasOne("ConfSys.Domain.Entity.Project", "Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConfSys.Domain.Entity.User", "User")
                        .WithMany("Members")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Project", b =>
                {
                    b.HasOne("ConfSys.Domain.Entity.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.User", b =>
                {
                    b.HasOne("ConfSys.Domain.Entity.Origin", "Origin")
                        .WithMany("Users")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Origin", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.Project", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("ConfSys.Domain.Entity.User", b =>
                {
                    b.Navigation("FamilyMembers");

                    b.Navigation("Members");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}