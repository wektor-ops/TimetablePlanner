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
        internal static int _iddistributor  = 1;
        string _firstname;
        string _lastname;
        public int StudentId { get { return _studentId; }
            set { _studentId = value; }
        }
        public string Firstname { get { return _firstname; }
                                    set { _firstname = value; }
        }
        public string Lastname { get { return _lastname; }
            set { _lastname = value; }
        }


       
        public Student(string firstname, string lastname)
        {
            _studentId = _iddistributor++;
            _firstname = firstname;
            _lastname = lastname;
            Schoolclass.AssignStudent(this);
        }
        public Student()
        { }

    }
}
