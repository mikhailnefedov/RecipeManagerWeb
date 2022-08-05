﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeManagerWeb.Data;

#nullable disable

namespace RecipeManagerWeb.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("RecipeManagerWeb.Models.GroceryCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GroceryCategories");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.GroceryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroceryCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroceryCategoryId");

                    b.ToTable("GroceryItems");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.InstructionStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("InstructionSteps");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PortionUnit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipeCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Vegetarian")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeCategoryId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.RecipeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.RecipeGroceryItem", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroceryItemId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("Measurementunit")
                        .HasColumnType("INTEGER");

                    b.HasKey("RecipeId", "GroceryItemId");

                    b.HasIndex("GroceryItemId");

                    b.ToTable("RecipeGroceryItems");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.GroceryItem", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.GroceryCategory", "GroceryCategory")
                        .WithMany("GroceryItems")
                        .HasForeignKey("GroceryCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroceryCategory");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.InstructionStep", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.Recipe", "Recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.RecipeCategory", "RecipeCategory")
                        .WithMany()
                        .HasForeignKey("RecipeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeCategory");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.RecipeGroceryItem", b =>
                {
                    b.HasOne("RecipeManagerWeb.Models.GroceryItem", "GroceryItem")
                        .WithMany()
                        .HasForeignKey("GroceryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeManagerWeb.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroceryItem");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.GroceryCategory", b =>
                {
                    b.Navigation("GroceryItems");
                });

            modelBuilder.Entity("RecipeManagerWeb.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}
