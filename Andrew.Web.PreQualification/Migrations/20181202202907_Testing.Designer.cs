﻿// <auto-generated />
using Andrew.Web.PreQualification.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Andrew.Web.PreQualification.Migrations
{
    [DbContext(typeof(PreQualificationContext))]
    [Migration("20181202202907_Testing")]
    partial class Testing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Andrew.Web.PreQualification.Models.PreQualModels.CcModels.Card", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Apr")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<string>("CardName")
                        .HasMaxLength(150);

                    b.Property<int>("MaxAgeMonths");

                    b.Property<decimal>("MaxIncomeGbp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("MinAgeMonths");

                    b.Property<decimal>("MinIncomeGbp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("PromotionalMessage")
                        .HasMaxLength(400);

                    b.HasKey("ID");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Andrew.Web.PreQualification.Models.PreQualModels.CcModels.CardApplication", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AnnualIncomeGbp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .HasMaxLength(150);

                    b.Property<DateTime>("SubmissionDate");

                    b.Property<string>("ValidationToken")
                        .HasMaxLength(150);

                    b.HasKey("ID");

                    b.ToTable("CardApplication");
                });

            modelBuilder.Entity("Andrew.Web.PreQualification.Models.PreQualModels.CcModels.CardApplicationResult", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<long>("ApplicationID");

                    b.Property<decimal>("Apr")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<long>("CardID");

                    b.Property<string>("CardName")
                        .HasMaxLength(150);

                    b.Property<string>("PromotionalMessage")
                        .HasMaxLength(400);

                    b.HasKey("ID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("CardID");

                    b.ToTable("CardApplicationResult");
                });

            modelBuilder.Entity("Andrew.Web.PreQualification.Models.PreQualModels.CcModels.CardApplicationResult", b =>
                {
                    b.HasOne("Andrew.Web.PreQualification.Models.PreQualModels.CcModels.CardApplication", "CardApplication")
                        .WithMany()
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Andrew.Web.PreQualification.Models.PreQualModels.CcModels.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
