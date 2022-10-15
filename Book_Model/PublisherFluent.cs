using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class PublisherFluent
    {
        
        public int Id_Pubisher { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public List<BookFluent> BookFluent { get;set; }
      
    }
}
