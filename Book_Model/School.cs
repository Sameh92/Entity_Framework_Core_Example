using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<Student> students { get; set; }  
    }
}
