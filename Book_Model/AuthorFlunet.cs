using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class AuthorFlunet
    {

        public int Autor_Id_flunet { get; set; }        
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public ICollection<BookAuthorFluent> BookAuthorFluent { get; set; }


    }
}
