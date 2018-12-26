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
    [Migration("20181226222144_AddDataModel")]
    partial class AddDataModel
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

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("EndTime");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StartTime");

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("teamWcrh.Models.JoinRequest", b =>
                {
                    b.Property<int>("JoinRequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message");

                    b.Property<string>("MobileNo");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectInterestedIn");

                    b.Property<string>("skill");

                    b.HasKey("JoinRequestId");

                    b.ToTable("JoinRequests");
                });

            modelBuilder.Entity("teamWcrh.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("teamWcrh.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe");

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("GalleryImage");

                    b.Property<string>("Message");

                    b.Property<string>("MessageTitle");

                    b.Property<string>("MobileNo");

                    b.Property<string>("Name");

                    b.Property<string>("PrimaryOccupation");

                    b.Property<string>("ProfileUrl");

                    b.Property<string>("Quote");

                    b.Property<string>("SecondaryOccupation");

                    b.Property<string>("Skill1Details");

                    b.Property<string>("Skill1Title");

                    b.Property<string>("Skill2Details");

                    b.Property<string>("Skill2Title");

                    b.Property<string>("Skill3Details");

                    b.Property<string>("Skill3Title");

                    b.Property<string>("WtsUpNo");

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
