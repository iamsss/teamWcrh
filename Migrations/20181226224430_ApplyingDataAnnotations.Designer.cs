﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using teamWcrh.Persistence;

namespace teamWcrh.Migrations
{
    [DbContext(typeof(teamWCRHDbContext))]
    [Migration("20181226224430_ApplyingDataAnnotations")]
    partial class ApplyingDataAnnotations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("teamWcrh.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("EndTime")
                        .HasMaxLength(20);

                    b.Property<string>("Image")
                        .HasMaxLength(255);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StartTime")
                        .HasMaxLength(20);

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("teamWcrh.Models.JoinRequest", b =>
                {
                    b.Property<int>("JoinRequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<string>("MobileNo")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ProjectInterestedIn");

                    b.Property<string>("skill")
                        .HasMaxLength(500);

                    b.HasKey("JoinRequestId");

                    b.ToTable("JoinRequests");
                });

            modelBuilder.Entity("teamWcrh.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(25);

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("teamWcrh.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe")
                        .HasMaxLength(1000);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("GalleryImage");

                    b.Property<string>("Message")
                        .HasMaxLength(1000);

                    b.Property<string>("MessageTitle")
                        .HasMaxLength(100);

                    b.Property<string>("MobileNo")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PrimaryOccupation")
                        .HasMaxLength(50);

                    b.Property<string>("ProfileUrl")
                        .HasMaxLength(255);

                    b.Property<string>("Quote")
                        .HasMaxLength(500);

                    b.Property<string>("SecondaryOccupation")
                        .HasMaxLength(50);

                    b.Property<string>("Skill1Details")
                        .HasMaxLength(500);

                    b.Property<string>("Skill1Title")
                        .HasMaxLength(50);

                    b.Property<string>("Skill2Details")
                        .HasMaxLength(500);

                    b.Property<string>("Skill2Title")
                        .HasMaxLength(50);

                    b.Property<string>("Skill3Details")
                        .HasMaxLength(500);

                    b.Property<string>("Skill3Title")
                        .HasMaxLength(50);

                    b.Property<string>("WtsUpNo")
                        .HasMaxLength(15);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("teamWcrh.Models.UserEvent", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("EventId");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent");
                });

            modelBuilder.Entity("teamWcrh.Models.UserProject", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ProjectId");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProject");
                });

            modelBuilder.Entity("teamWcrh.Models.UserEvent", b =>
                {
                    b.HasOne("teamWcrh.Models.Event", "Event")
                        .WithMany("UserEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("teamWcrh.Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("teamWcrh.Models.UserProject", b =>
                {
                    b.HasOne("teamWcrh.Models.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("teamWcrh.Models.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
