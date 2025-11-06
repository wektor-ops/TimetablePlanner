using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TimetablePlanner
{
    internal class Subject
    {
        private string _abbreviation;
     
        public string Abbreviation
        {
            get { return _abbreviation }; 
            set;
        }

        public Subject(String Abbreviation) 
        {
            Abbreviation.this = Abbreviation; 
        }
    }
}
