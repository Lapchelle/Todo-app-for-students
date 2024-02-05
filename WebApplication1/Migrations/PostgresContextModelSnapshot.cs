﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WebApplication1.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("WebApplication1.Models.Status_Tasks", b =>
                {
                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("StatusId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("StatusTasks");
                });

            modelBuilder.Entity("WebApplication1.Models.Status_targets", b =>
                {
                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("StatusId", "TargetId");

                    b.HasIndex("TargetId");

                    b.ToTable("StatusTargets");
                });

            modelBuilder.Entity("WebApplication1.Models.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("WebApplication1.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.User_contacts", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("WebApplication1.Models.User_targets", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TargetId");

                    b.HasIndex("TargetId");

                    b.ToTable("User_Targets");
                });

            modelBuilder.Entity("WebApplication1.Models.User_tasks", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("User_Tasks");
                });

            modelBuilder.Entity("WebApplication1.Models.Status_Tasks", b =>
                {
                    b.HasOne("WebApplication1.Models.Status", "Status")
                        .WithMany("Status_Tasks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Task", "Task")
                        .WithMany("Status_Tasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WebApplication1.Models.Status_targets", b =>
                {
                    b.HasOne("WebApplication1.Models.Status", "Status")
                        .WithMany("Status_targets")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Target", "Target")
                        .WithMany("Status_targets")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("WebApplication1.Models.User_contacts", b =>
                {
                    b.HasOne("WebApplication1.Models.Contact", "Contact")
                        .WithMany("User_contacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("User_contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.User_targets", b =>
                {
                    b.HasOne("WebApplication1.Models.Target", "Target")
                        .WithMany("User_Targets")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("User_Targets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Target");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.User_tasks", b =>
                {
                    b.HasOne("WebApplication1.Models.Task", "Task")
                        .WithMany("User_tasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("User_tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Contact", b =>
                {
                    b.Navigation("User_contacts");
                });

            modelBuilder.Entity("WebApplication1.Models.Status", b =>
                {
                    b.Navigation("Status_Tasks");

                    b.Navigation("Status_targets");
                });

            modelBuilder.Entity("WebApplication1.Models.Target", b =>
                {
                    b.Navigation("Status_targets");

                    b.Navigation("User_Targets");
                });

            modelBuilder.Entity("WebApplication1.Models.Task", b =>
                {
                    b.Navigation("Status_Tasks");

                    b.Navigation("User_tasks");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Navigation("User_Targets");

                    b.Navigation("User_contacts");

                    b.Navigation("User_tasks");
                });
#pragma warning restore 612, 618
        }
    }
}