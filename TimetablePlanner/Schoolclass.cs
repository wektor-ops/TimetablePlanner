using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner    
{
    internal class Schoolclass
    {

        private string _abbreviation;
        public List<Schoolclass> SchoolClass = new List<Schoolclass()>
        public List<Subject> curriculum = new List<Subject()>
        public string Abbreviation 
        {
            get { return _abbreviation}
            set { }
        }
        public void  AddSubjectToLehrplan(Subject subject, int NumLessions) 
        {
            for (int i = 0; i < NumLessions; i++)
            {
                curriculum.Add(subject);
            }
        }
    }
}
 