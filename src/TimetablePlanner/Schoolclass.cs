using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    public class Schoolclass
    {
        public static List<Schoolclass> AllClasses = new List<Schoolclass>();
        [JsonIgnore]
        public TimetableSlot[,] ClassPlan { get; set; }

        public string Abbreviation { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Subject> Curriculum { get; set; } = new List<Subject>();

        public int MaxCapacity { get; set; }  = 20;
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
            if (Teacher.AllTeachers.Count >= AllClasses.Count && Room.AllRooms.Count >= AllClasses.Count)
                Timetable.Build();
            else Console.WriteLine("Not enough teachers/rooms available.");

        }

        public void AddToCurriculum(Subject subject, int perweek)
        {
            if (Curriculum.Count + perweek > Timetable.Days * Timetable.Hours)
            {
                Console.WriteLine("not enough lessons to add {0}", subject.Abbreviation);
                return;
            }
            for (int i = 0; i < perweek; i++)
            {
                Curriculum.Add(subject);
            }
        }
        public static string GenerateNewAbbreviation()
        {
            int currentYear = DateTime.Now.Year % 100; 

            if (AllClasses.Count == 0)
                return $"A{currentYear:D2}A";

            string last = AllClasses.Last().Abbreviation;

            char prefix = last[0];
            char suffix = last[3];

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
            return true;
        }
        public Schoolclass Clone()
        {
            Schoolclass newClass = new Schoolclass
            {
                Abbreviation = this.Abbreviation,
                MaxCapacity = this.MaxCapacity,

                Students = this.Students.ToList(), 
                Curriculum = this.Curriculum.ToList(), 
            };

            newClass.ClassPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];

            for (int d = 0; d < Timetable.Days; d++)
            {
                for (int h = 0; h < Timetable.Hours; h++)
                {
                    TimetableSlot originalSlot = this.ClassPlan[d, h];

                    if (originalSlot != null)
                    {
                        newClass.ClassPlan[d, h] = originalSlot.Clone();
                    }
                    else
                    {
                        newClass.ClassPlan[d, h] = null;
                    }
                }
            }

            return newClass;
        }
        public Schoolclass()
        { }

    }
}
    

 
