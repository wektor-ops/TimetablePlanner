using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TimetablePlanner
{
    public class Subject
    {
        private string _abbreviation;
        public static List<Subject> AllSubjects = new List<Subject>();

        public string Abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }

        public Subject(string abbreviation)
        {
            Abbreviation = abbreviation;
            AllSubjects.Add(this);
        }
    }
}