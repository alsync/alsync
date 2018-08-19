﻿// <auto-generated />
using Alsync.Domain.Models;
using Alsync.Domain.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Alsync.Domain.Repositories.Migrations
{
    [DbContext(typeof(AlsyncDbContext))]
    [Migration("20171127180330_user")]
    partial class user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alsync.Domain.Models.Contact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<Guid>("ProfileID");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("ID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Alsync.Domain.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Password");

                    b.Property<byte[]>("RowVersion")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Alsync.Domain.Models.UserProfile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<string>("Avatar");

                    b.Property<string>("Company");

                    b.Property<int>("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("ID");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("Alsync.Domain.Models.Contact", b =>
                {
                    b.HasOne("Alsync.Domain.Models.UserProfile", "Profile")
                        .WithMany("Phones")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
