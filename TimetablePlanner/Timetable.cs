using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Timetable
    {
        public static int Days = 5;
        public static int Hours = 8; 
        public void OutputStundenplan() 
        {
            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║       Mo       ║       Di       ║       Mi       ║       Do       ║       Fr       ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 08:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 09:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 10:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 11:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 12:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
            Console.WriteLine("║        ║                ║                ║                ║                ║                ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 14:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 17:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 18:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");

        }
            



    }

    // 2. ClassTimetable
    internal class ClassTimetable
    {
        public Schoolclass Class { get; set; }
        public TimetableSlot[,] Slots;

        public ClassTimetable(Schoolclass c)
        {
            Class = c;
            Slots = new TimetableSlot[Timetable.Days, Timetable.Hours];
        }
    }
    // 3. TeacherTimetable
    internal class TeacherTimetable
    {
        public Teacher Teacher { get; set; }
        public TimetableSlot[,] Slots;

        public TeacherTimetable(Teacher t)
        {
            Teacher = t;
            Slots = new TimetableSlot[Timetable.Days, Timetable.Hours];
        }
    }
    // 4. RoomTimetable
    internal class RoomTimetable
    {
        public Room Room { get; set; }
        public TimetableSlot[,] Slots;

        public RoomTimetable(Room r)
        {
            Room = r;
            Slots = new TimetableSlot[Timetable.Days, Timetable.Hours];
        }
    }

    // 5. TimetableWorld
    internal class TimetableWorld
    {
        public List<ClassTimetable> ClassPlans = new List<ClassTimetable>();
        public List<TeacherTimetable> TeacherPlans = new List<TeacherTimetable>();
        public List<RoomTimetable> RoomPlans = new List<RoomTimetable>();
    }
}
