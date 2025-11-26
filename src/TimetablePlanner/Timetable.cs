using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Timetable
    {
        public const int Days = 5;
        public const int Hours = 8; 
        public static int penalty_Gap = 5;
        public static int penalty_RoomChange = 2;
        public static int penalty_EdgeHour = 5;
        public static int penalty_RoomsUse = 4;
        public static void OutputStundenplan()
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
            foreach (Schoolclass schoolClass in Schoolclass.AllClasses)
            {
                Student foundStudent = schoolClass.Students.Find(s => s.Firstname == "Jan");
                if (foundStudent != null)
                {
                    Console.Write(schoolClass.Abbreviation);
                    Console.Write(schoolClass.ClassPlan[0, 0].assignedSubject.Abbreviation);
                    Console.Write(schoolClass.ClassPlan[0, 0].assignedRoom.Abbreviation);
                    Console.Write(schoolClass.ClassPlan[0, 0].assignedTeacher.Abbreviation);
                }
            }
            Console.Write(Room.AllRooms.Find(r => r.Abbreviation == "D24a").RoomPlan[0, 0]);
            Console.Write(Teacher.AllTeachers.Find(t => t.Firstname == "Jan").TeacherPlan[0, 0]);
        }
        public static void Build()
        {
            Random rand = new Random();

            foreach (Schoolclass classPlan in Schoolclass.AllClasses)
            {
                foreach (Subject subject in classPlan.Curriculum)
                {
                    bool placed = false;

                    // Suche Tag/Hour
                    for (int d = 0; d < Days && !placed; d++)
                    {
                        for (int h = 0; h < Hours && !placed; h++)
                        {
                            if (classPlan.ClassPlan[d, h] == null)
                            {
                                placed = false;
                                int attempts = 0;
                                int maxAttempts = 50; // Abbruch, falls kein freier Lehrer/Raum gefunden wird

                                while (attempts < maxAttempts && !placed)
                                {

                                    // Lehrer zufällig wählen (alle können alles)
                                    Teacher t = Teacher.AllTeachers[rand.Next(Teacher.AllTeachers.Count)];

                                    // Raum zufällig wählen
                                    Room r = Room.AllRooms[rand.Next(Room.AllRooms.Count)];

                                    if (t.TeacherPlan[d, h] == null
                                        && t.Availability[d, h] == true
                                        && r.RoomPlan[d, h] == null)
                                    {

                                        TimetableSlot slot = new TimetableSlot(t, subject, r, classPlan, d, h);

                                        // Slot eintragen
                                        classPlan.ClassPlan[d, h] = slot;
                                        t.TeacherPlan[d, h] = slot;
                                        r.RoomPlan[d, h] = slot;

                                        placed = true;
                                    }
                                }

                                if (!placed)
                                {
                                    // Notfall: wenn kein freier Slot gefunden → Warnung
                                    Console.WriteLine($"Warnung: {subject} konnte nicht für Klasse {classPlan.Abbreviation} eingetragen werden. Zu wenig Lehrer oder Räume");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
