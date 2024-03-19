﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAtrio.UsersJobsManagement.Infrastructure;

#nullable disable

namespace WebAtrio.UsersJobsManagement.Infrastructure.Migrations
{
    [DbContext(typeof(UJDbContext))]
    partial class UJDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAtrio.UsersJobsManagement.Models.Entities.JobEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("company_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("position");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("t_jobs");
                });

            modelBuilder.Entity("WebAtrio.UsersJobsManagement.Models.Entities.PersonEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("lastname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("t_persons");
                });

            modelBuilder.Entity("WebAtrio.UsersJobsManagement.Models.Entities.JobEntity", b =>
                {
                    b.HasOne("WebAtrio.UsersJobsManagement.Models.Entities.PersonEntity", "Person")
                        .WithMany("Persons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebAtrio.UsersJobsManagement.Models.Entities.PersonEntity", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
