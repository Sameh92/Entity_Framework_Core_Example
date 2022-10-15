using Book_Model;
using BookDataAccess.FluentConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        //add for view
        public DbSet<BookDetailsFromView> BookDetailsFromViews { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Book_Id, ba.Author_Id });

            //Change Fluent
            modelBuilder.Entity<ChangeFluent>().HasKey(c => c.ChangeFluent_ID);
            modelBuilder.Entity<ChangeFluent>().ToTable("tbl_Flunet");
            modelBuilder.Entity<ChangeFluent>().Property(c => c.ChangeFluent_Name).HasColumnName("Title");
            //Author
            modelBuilder.Entity<Author>().Ignore(b => b.Age);
            //book
            modelBuilder.Entity<BookFluent>().HasKey(b => b.Book_Id_Flent);
            modelBuilder.Entity<BookFluent>().Property(b => b.Title).IsRequired().HasMaxLength(15);
            // one to one relationship 
            modelBuilder.Entity<BookFluent>().HasOne(b => b.BookDetailFluent).WithOne(b => b.BookFluent).HasForeignKey<BookFluent>("BookDetail_Id");
            //one to many relation between book and publisher
            modelBuilder.Entity<BookFluent>().HasOne(b => b.PublisherFluent).WithMany(b => b.BookFluent).HasForeignKey(b => b.Publishers_Id);

            // add Id to Author
            modelBuilder.Entity<AuthorFlunet>().HasKey(b => b.Autor_Id_flunet);
            // add Id to publisher
            modelBuilder.Entity<PublisherFluent>().HasKey(b => b.Id_Pubisher);
            // add Id to bookDetal
            modelBuilder.Entity<BookDetailFluent>().HasKey(b => b.Id_BookDetailFluent);

            //for view
            modelBuilder.Entity<BookDetailsFromView>().HasNoKey().ToView("GetOnlyBookDetails");
            // orgnize the code
            modelBuilder.ApplyConfiguration(new BookAuthorConfig());

          
        }

    }
}
