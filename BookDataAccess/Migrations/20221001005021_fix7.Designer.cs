﻿// <auto-generated />
using System;
using BookDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221001005021_fix7")]
    partial class fix7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Book_Model.Author", b =>
                {
                    b.Property<int>("Autor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Autor_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Book_Model.AuthorFlunet", b =>
                {
                    b.Property<int>("Autor_Id_flunet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Autor_Id_flunet");

                    b.ToTable("AuthorFlunet");
                });

            modelBuilder.Entity("Book_Model.Book", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookDetail_Id")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfchapters")
                        .HasColumnType("int");

                    b.Property<int>("Publishers_Id")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Book_Id");

                    b.HasIndex("BookDetail_Id")
                        .IsUnique();

                    b.HasIndex("Publishers_Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Book_Model.BookAuthor", b =>
                {
                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.HasKey("Book_Id", "Author_Id");

                    b.HasIndex("Author_Id");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Book_Model.BookAuthorFluent", b =>
                {
                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.HasKey("Book_Id", "Author_Id");

                    b.HasIndex("Author_Id");

                    b.ToTable("BookAuthorFluent");
                });

            modelBuilder.Entity("Book_Model.BookDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NumberOfPage")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("Book_Model.BookDetailFluent", b =>
                {
                    b.Property<int>("Id_BookDetailFluent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NumberOfPage")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_BookDetailFluent");

                    b.ToTable("BookDetailFluent");
                });

            modelBuilder.Entity("Book_Model.BookFluent", b =>
                {
                    b.Property<int>("Book_Id_Flent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookDetail_Id")
                        .HasColumnType("int");

                    b.Property<int>("Publishers_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Book_Id_Flent");

                    b.HasIndex("BookDetail_Id")
                        .IsUnique();

                    b.HasIndex("Publishers_Id");

                    b.ToTable("BookFluent");
                });

            modelBuilder.Entity("Book_Model.ChangeFluent", b =>
                {
                    b.Property<int>("ChangeFluent_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChangeFluent_Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("ChangeFluent_ID");

                    b.ToTable("tbl_Flunet");
                });

            modelBuilder.Entity("Book_Model.Publisher", b =>
                {
                    b.Property<int>("Id_Pubisher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Pubisher");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("Book_Model.PublisherFluent", b =>
                {
                    b.Property<int>("Id_Pubisher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Pubisher");

                    b.ToTable("PublisherFluent");
                });

            modelBuilder.Entity("Book_Model.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Book_Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Book_Model.Book", b =>
                {
                    b.HasOne("Book_Model.BookDetail", "bookDetail")
                        .WithOne("book")
                        .HasForeignKey("Book_Model.Book", "BookDetail_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Model.Publisher", "Publishers")
                        .WithMany("Books")
                        .HasForeignKey("Publishers_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bookDetail");

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("Book_Model.BookAuthor", b =>
                {
                    b.HasOne("Book_Model.Author", "Authors")
                        .WithMany("BookAuthors")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Model.Book", "Books")
                        .WithMany("BookAuthors")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book_Model.BookAuthorFluent", b =>
                {
                    b.HasOne("Book_Model.AuthorFlunet", "AuthorFlunet")
                        .WithMany("BookAuthorFluent")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Model.BookFluent", "BookFluent")
                        .WithMany("BookAuthorFluent")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorFlunet");

                    b.Navigation("BookFluent");
                });

            modelBuilder.Entity("Book_Model.BookFluent", b =>
                {
                    b.HasOne("Book_Model.BookDetailFluent", "BookDetailFluent")
                        .WithOne("BookFluent")
                        .HasForeignKey("Book_Model.BookFluent", "BookDetail_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Model.PublisherFluent", "PublisherFluent")
                        .WithMany("BookFluent")
                        .HasForeignKey("Publishers_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookDetailFluent");

                    b.Navigation("PublisherFluent");
                });

            modelBuilder.Entity("Book_Model.Student", b =>
                {
                    b.HasOne("Book_Model.School", "School")
                        .WithMany("students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Book_Model.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Book_Model.AuthorFlunet", b =>
                {
                    b.Navigation("BookAuthorFluent");
                });

            modelBuilder.Entity("Book_Model.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Book_Model.BookDetail", b =>
                {
                    b.Navigation("book");
                });

            modelBuilder.Entity("Book_Model.BookDetailFluent", b =>
                {
                    b.Navigation("BookFluent");
                });

            modelBuilder.Entity("Book_Model.BookFluent", b =>
                {
                    b.Navigation("BookAuthorFluent");
                });

            modelBuilder.Entity("Book_Model.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book_Model.PublisherFluent", b =>
                {
                    b.Navigation("BookFluent");
                });

            modelBuilder.Entity("Book_Model.School", b =>
                {
                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}
