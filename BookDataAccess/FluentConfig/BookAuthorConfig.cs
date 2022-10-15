using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDataAccess.FluentConfig
{
    public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthorFluent>
    {
        public void Configure(EntityTypeBuilder<BookAuthorFluent> builder)
        {
            builder.HasKey(ba => new { ba.Book_Id, ba.Author_Id });
            builder.HasOne(b=>b.BookFluent).WithMany(b=>b.BookAuthorFluent).HasForeignKey(b=>b.Book_Id);
            builder.HasOne(b => b.AuthorFlunet).WithMany(b => b.BookAuthorFluent).HasForeignKey(b => b.Author_Id);
        }
    }
}
