using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Teacher
    {
        public static List<Teacher> AllTeachers = new List<Teacher>();

        int _teacherId;
        static int _iddistributor = 1;
        string _abbreviation;
        string _firstname;
        string _lastName;

        public int TeacherId { get { return _teacherId; }}
        public string Abbrevation { get { return _abbreviation; }}
        public string Firstname { get { return _firstname; } set { _firstname = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public bool[,] Availability { get; set; } = new bool[Timetable.days, Timetable.hours];
        // wichtig wenn jan fertig ist mit Timetable public static int days = 5; und public static int hours = ??; hinzufügen

        public Teacher(string newFirstname, string newLastname, bool[,] newAvailability)
        {
            _teacherId = _iddistributor++;
            Firstname = newFirstname;
            LastName = newLastname;
            _abbreviation = newLastname.Substring(0, 2).ToUpper() + newFirstname.Substring(0, 1).ToUpper();
            Availability = newAvailability;
            AllTeachers.Add(this);
        }
        
    }
}
