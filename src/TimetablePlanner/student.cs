using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    public class Student
    {
        int _studentId;
        internal static int _iddistributor = 1;
        string _firstname;
        string _lastname;
        public int StudentId { get { return _studentId; } }
        public string Firstname { get { return _firstname; } }
        public string Lastname { get { return _lastname; } }


       
        public Student(string firstname, string lastname)
        {
            _studentId = _iddistributor++;
            _firstname = firstname;
            _lastname = lastname;
            Schoolclass.AssignStudent(this);
        }

    }
}
