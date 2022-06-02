﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace rskp1.Migrations
{
    [DbContext(typeof(EducationContext))]
    [Migration("20220601210608_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppDocId")
                        .HasColumnType("integer")
                        .HasColumnName("app_doc_id");

                    b.Property<int>("AppPatientId")
                        .HasColumnType("integer")
                        .HasColumnName("app_patient_id");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer")
                        .HasColumnName("facility_id");

                    b.HasKey("Id")
                        .HasName("pk_appointments");

                    b.HasIndex("AppDocId")
                        .HasDatabaseName("ix_appointments_app_doc_id");

                    b.HasIndex("AppPatientId")
                        .HasDatabaseName("ix_appointments_app_patient_id");

                    b.HasIndex("FacilityId")
                        .HasDatabaseName("ix_appointments_facility_id");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("occupation");

                    b.HasKey("Id")
                        .HasName("pk_doctors");

                    b.ToTable("doctors", (string)null);
                });

            modelBuilder.Entity("Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("facility_name");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_facilities");

                    b.HasIndex("DoctorId")
                        .HasDatabaseName("ix_facilities_doctor_id");

                    b.ToTable("facilities", (string)null);
                });

            modelBuilder.Entity("MedicalFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("pk_medical_files");

                    b.HasIndex("PatientId")
                        .HasDatabaseName("ix_medical_files_patient_id");

                    b.ToTable("medical_files", (string)null);
                });

            modelBuilder.Entity("Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.HasKey("Id")
                        .HasName("pk_patients");

                    b.ToTable("patients", (string)null);
                });

            modelBuilder.Entity("Appointment", b =>
                {
                    b.HasOne("Doctor", "AppDoc")
                        .WithMany()
                        .HasForeignKey("AppDocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_doctors_app_doc_id");

                    b.HasOne("Patient", "AppPatient")
                        .WithMany("Appointment")
                        .HasForeignKey("AppPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_patients_app_patient_id");

                    b.HasOne("Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_facilities_facility_id");

                    b.Navigation("AppDoc");

                    b.Navigation("AppPatient");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Facility", b =>
                {
                    b.HasOne("Doctor", null)
                        .WithMany("Facility")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("fk_facilities_doctors_doctor_id");
                });

            modelBuilder.Entity("MedicalFile", b =>
                {
                    b.HasOne("Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_medical_files_patients_patient_id");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Doctor", b =>
                {
                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Patient", b =>
                {
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
