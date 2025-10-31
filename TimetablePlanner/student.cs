using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Student
    {
        int _studentId;
        string _name;
        string _lastname;
        public Schoolclass _class;
        public List<Subject> _additionalSubject;
        public int StudentId { get { return _studentId; } }
        public string Name { get { return _name; } }
        public string Lastname { get { return _lastname; } }

       
        public Student()
        {
            
        }

    }
}
