﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wellness_Score_API.DataContext;

#nullable disable

namespace WellnessScoreAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230216053445_Updated Datatypes")]
    partial class UpdatedDatatypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wellness_Score_API.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coverage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiagnosisId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("DiagnosisId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Wellness_Score_API.Models.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("BMI")
                        .HasColumnType("real");

                    b.Property<float>("Cholesterol")
                        .HasColumnType("real");

                    b.Property<float>("Creatinine")
                        .HasColumnType("real");

                    b.Property<string>("ECG_TMT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ESR")
                        .HasColumnType("real");

                    b.Property<float>("HBA1C_FBS")
                        .HasColumnType("real");

                    b.Property<float>("HBP")
                        .HasColumnType("real");

                    b.Property<float>("Hemoglobin")
                        .HasColumnType("real");

                    b.Property<float>("LBP")
                        .HasColumnType("real");

                    b.Property<string>("MER")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Pulse")
                        .HasColumnType("real");

                    b.Property<float>("SGPT")
                        .HasColumnType("real");

                    b.Property<int?>("WellnessScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Wellness_Score_API.Models.Customer", b =>
                {
                    b.HasOne("Wellness_Score_API.Models.Diagnosis", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisId");

                    b.Navigation("Diagnosis");
                });
#pragma warning restore 612, 618
        }
    }
}
