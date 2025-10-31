using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Teacher
    {
        int _teacherId;
        static int Iddistributor = 1;
        string _abbreviation;
        string _firstname;
        string _lastName;

        public int TeacherId { get { return _teacherId; }}
        public string Abbrevation { get { return _abbreviation; }}
        public string Firstname { get { return _firstname; } set { _firstname = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        public Teacher(string newFirstname, string newLastname)
        {
            _teacherId = Iddistributor++;
            Firstname = newFirstname;
            LastName = newLastname;
            _abbreviation = newLastname.Substring(0, 2).ToUpper() + newFirstname.Substring(0, 1).ToUpper();
        }
        
    }
}
