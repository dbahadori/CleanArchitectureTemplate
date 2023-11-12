﻿// <auto-generated />
using System;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.ActivityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ActivityEntity");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.BookmarkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("BookmarkEntity");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.IngredientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.RecipeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("CookingTime")
                        .HasColumnType("time");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RecipeEntity");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.SessionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FireBaseToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastLoggedindAt")
                        .HasColumnType("bigint");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SessionEntity");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.SettingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("SettingEntity");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.TempDataEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastSendDateAt")
                        .HasColumnType("bigint");

                    b.Property<int>("SendCount")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TempDataEntity");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThirdPartyType")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.UserProfileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LastModified")
                        .HasColumnType("bigint");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfileEntity");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("User_Roles", (string)null);
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.ActivityEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.UserProfileEntity", "UserProfile")
                        .WithMany("Activities")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.BookmarkEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.UserProfileEntity", "UserProfile")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.IngredientEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.RecipeEntity", "Recipe")
                        .WithMany("IngredientEntitys")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.SessionEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.UserEntity", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.SettingEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.SessionEntity", "Session")
                        .WithMany("Settings")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.TempDataEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.UserEntity", "User")
                        .WithMany("TempData")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.UserProfileEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.UserEntity", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("CleanArchitectureReferenceTemplate.Domain.Entities.UserProfileEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitectureReferenceTemplate.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.RecipeEntity", b =>
                {
                    b.Navigation("IngredientEntitys");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.SessionEntity", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("TempData");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CleanArchitectureReferenceTemplate.Domain.Entities.UserProfileEntity", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Bookmarks");
                });
#pragma warning restore 612, 618
        }
    }
}