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
        private List<Subject> SubjectList = new List<Subject>();
        public string Abbreviation
        {
            get { return _abbreviation }; set;
        }
        

    }
}
