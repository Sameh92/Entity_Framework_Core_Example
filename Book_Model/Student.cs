using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
