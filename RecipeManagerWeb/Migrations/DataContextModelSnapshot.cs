﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeManagerWeb.Data;

namespace RecipeManagerWeb.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeManagerWeb.Models.Groceries.GroceryCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroceryCategories");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Groceries.GroceryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroceryCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroceryCategoryId");

                    b.ToTable("GroceryItems");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.InstructionStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("InstructionSteps");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortionUnit")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RecipeCategoryId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.RecipeGroceryItem", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("GroceryItemId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("Measurementunit")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "GroceryItemId");

                    b.HasIndex("GroceryItemId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.RecipeCategories.RecipeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Groceries.GroceryItem", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.Groceries.GroceryCategory", "GroceryCategory")
                        .WithMany()
                        .HasForeignKey("GroceryCategoryId");

                    b.Navigation("GroceryCategory");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.InstructionStep", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.Recipe.Recipe", "Recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.Recipe", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.RecipeCategories.RecipeCategory", "RecipeCategory")
                        .WithMany()
                        .HasForeignKey("RecipeCategoryId");

                    b.Navigation("RecipeCategory");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.RecipeGroceryItem", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.Groceries.GroceryItem", "GroceryItem")
                        .WithMany()
                        .HasForeignKey("GroceryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeManagerWeb.Models.Recipe.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroceryItem");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}