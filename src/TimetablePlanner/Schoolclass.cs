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
        public static List<Schoolclass> AllClasses = new List<Schoolclass>();
        public TimetableSlot[,] ClassPlan;

        public string Abbreviation = "";
        public List<Student> Students = new List<Student>();
        public List<Subject> Curriculum = new List<Subject>();

        public int MaxCapacity = 20;
        public bool IsFull { get { if (Students.Count >= MaxCapacity) return true; return false; } }

        public static void AssignStudent(Student s)
        {
            foreach (Schoolclass c in AllClasses)
            {
                if (!c.IsFull)
                {
                    c.AddStudent(s);
                    return;
                }
            }

            if (AllClasses.Count > 0)
            {
                Schoolclass oldClass = AllClasses.Last();
                SplitClass(oldClass, s);
            }
            else
            {
                string firstAbbr = GenerateNewAbbreviation();
                Schoolclass newClass = new Schoolclass { Abbreviation = firstAbbr, ClassPlan = new TimetableSlot[Timetable.Days, Timetable.Hours] };
                newClass.AddStudent(s);
                AllClasses.Add(newClass);
            }
        }

        private static void SplitClass(Schoolclass oldClass, Student newStudent)
        {

            string newAbbr = GenerateNewAbbreviation();
            Schoolclass newClass = new Schoolclass { Abbreviation = newAbbr, ClassPlan = new TimetableSlot[Timetable.Days, Timetable.Hours] };

            List<Student> oldStudents = oldClass.Students.ToList();
            List<Student> remain = oldStudents.Take(11).ToList();
            List<Student> move = oldStudents.Skip(11).ToList();

            oldClass.Students = remain;
            foreach (Student m in move)
            {
                newClass.AddStudent(m);
            }

            newClass.AddStudent(newStudent);
            AllClasses.Add(newClass);

        }

        public void AddToCurriculum(Subject subject, int perweek)
        {
            for (int i = 0; i < perweek; i++)
            {
                Curriculum.Add(subject);
            }
        }
        private static string GenerateNewAbbreviation()
        {
            int currentYear = DateTime.Now.Year % 100; // Jahr berechnen

            if (AllClasses.Count == 0)
                return $"A{currentYear:D2}A";

            string last = AllClasses.Last().Abbreviation;

            char prefix = last[0];
            char suffix = last[3];

            // Wenn letzte Klasse "A25Z" ist, dann nächste Klasse "B25A"
            if (suffix == 'Z')
            {
                prefix = (char)(prefix + 1);
                suffix = 'A';
            }
            else
            {
                suffix = (char)(suffix + 1);
            }

            string next = $"{prefix}{currentYear:D2}{suffix}";
            return next;
        }
        public bool AddStudent(Student s)
        {
            if (IsFull) return false;
            Students.Add(s);
            s.Class = this;
            return true;
        }
    }

}
 