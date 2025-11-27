using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablePlanner;

namespace TimetablePlanner
{
    public class Timetable
    {
        public const int Days = 5;
        public const int Hours = 8;
        public static int penalty_Gap = 5;
        public static int penalty_RoomChange = 2;
        public static int penalty_EdgeHour = 5;
        public static int penalty_RoomsUse = 4;


        public static void OutputTimetable(Schoolclass schoolClass)
        {
            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║      Mo        ║      Di        ║      Mi        ║      Do        ║      Fr        ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");

            string[] times = { "08:00 ", "09:00 ", "10:00 ", "11:00 ", "12:00 ", "14:00 ", "15:00 ", "16:00 ", "17:00 ", "18:00 " };

            for (int stunde = 0; stunde < 9; stunde++)
            {
                if (stunde == 5)
                {
                    Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
                    Console.WriteLine("║        ║                ║                ║                ║                ║                ║");
                    Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
                    continue;
                }

                int planStunde = stunde < 5 ? stunde : stunde - 1;

                Console.Write($"║ {times[stunde]} ║");
                for (int tag = 0; tag < 5; tag++)
                {
                    TimetableSlot entry = schoolClass.ClassPlan[tag, planStunde];

                    string subjectAbbr = entry?.assignedSubject?.Abbreviation ?? "  ";
                    string teacherAbbr = entry?.assignedTeacher?.Abbreviation ?? "   ";

                    string output = $" {subjectAbbr}         {teacherAbbr} ";

                    Console.Write($"{output}║");

                    if (tag == 4)
                    {
                        Console.WriteLine();
                    }
                }

                Console.Write("║        ║");
                for (int tag = 0; tag < 5; tag++)
                {
                    TimetableSlot entry = schoolClass.ClassPlan[tag, planStunde];
                    string classAbbr;
                    if(entry != null)
                    classAbbr = schoolClass.Abbreviation;
                    else classAbbr = "    ";
                    // Raum: 4 Zeichen
                    string roomAbbr = entry?.assignedRoom?.Abbreviation ?? "    ";

                    string output = $" {classAbbr}      {roomAbbr} ";

                    Console.Write($"{output}║");

                    if (tag == 4)
                    {
                        Console.WriteLine();
                    }
                }

                if (stunde < 9 && stunde != 8)
                {
                    Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
                }
            }

            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");
        }

        public static void OutputTimetable(Teacher teacher)
        {
            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║      Mo        ║      Di        ║      Mi        ║      Do        ║      Fr        ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");

            string[] times = { "08:00 ", "09:00 ", "10:00 ", "11:00 ", "12:00 ", "14:00 ", "15:00 ", "16:00 ", "17:00 ", "18:00 " };

            for (int stunde = 0; stunde < 9; stunde++)
            {
                if (stunde == 5)
                {
                    Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
                    Console.WriteLine("║        ║                ║                ║                ║                ║                ║");
                    Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
                    continue;
                }

                int planStunde = stunde < 5 ? stunde : stunde - 1;

                Console.Write($"║ {times[stunde]} ║");
                for (int tag = 0; tag < 5; tag++)
                {
                    TimetableSlot entry = teacher.TeacherPlan[tag, planStunde];

                    string subjectAbbr = entry?.assignedSubject?.Abbreviation ?? "  ";
                    string classAbbr = entry?.assignedSchoolclass?.Abbreviation ?? "    ";

                    string output = $" {subjectAbbr}        {classAbbr} ";

                    Console.Write($"{output}║");

                    if (tag == 4)
                    {
                        Console.WriteLine();
                    }
                }

                Console.Write("║        ║");
                for (int tag = 0; tag < 5; tag++)
                {
                    TimetableSlot entry = teacher.TeacherPlan[tag, planStunde];
                    string teacherAbbr;
                    if (entry != null)
                        teacherAbbr = teacher.Abbreviation;
                    else teacherAbbr = "   ";
                        string roomAbbr = entry?.assignedRoom?.Abbreviation ?? "    ";

                    string output = $" {teacherAbbr}       {roomAbbr} ";

                    Console.Write($"{output}║");

                    if (tag == 4)
                    {
                        Console.WriteLine();
                    }
                }

                if (stunde < 9 && stunde != 8)
                {
                    Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
                }
            }

            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");
        }

        public static void OutputTimetable(Room room)
        {
            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║      Mo        ║      Di        ║      Mi        ║      Do        ║      Fr        ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");

            string[] times = { "08:00 ", "09:00 ", "10:00 ", "11:00 ", "12:00 ", "14:00 ", "15:00 ", "16:00 ", "17:00 ", "18:00 " };

            for (int stunde = 0; stunde < 9; stunde++)
            {
                if (stunde == 5)
                {
                    Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
                    Console.WriteLine("║        ║                ║                ║                ║                ║                ║");
                    Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
                    continue;
                }

                int planStunde = stunde < 5 ? stunde : stunde - 1;

                Console.Write($"║ {times[stunde]} ║");
                for (int tag = 0; tag < 5; tag++)
                {
                    TimetableSlot entry = room.RoomPlan[tag, planStunde];

                    string subjectAbbr = entry?.assignedSubject?.Abbreviation ?? "  ";
                    string classAbbr = entry?.assignedSchoolclass?.Abbreviation ?? "    ";


                    string output = $" {subjectAbbr}        {classAbbr} ";

                    Console.Write($"{output}║");

                    if (tag == 4)
                    {
                        Console.WriteLine();
                    }
                }

                Console.Write("║        ║");
                for (int tag = 0; tag < 5; tag++)
                {
                    dynamic entry = room.RoomPlan[tag, planStunde];

                    string teacherAbbr = entry?.assignedTeacher?.Abbreviation ?? "   ";
                    string roomAbbr;
                    if (entry != null)
                        roomAbbr = room.Abbreviation;
                    else roomAbbr = "    ";


                        string output = $" {teacherAbbr}       {roomAbbr} ";

                    Console.Write($"{output}║");

                    if (tag == 4)
                    {
                        Console.WriteLine();
                    }
                }

                if (stunde < 9 && stunde != 8)
                {
                    Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
                }
            }

            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");
        }
    


public static void Build()
{
    ClearAllPlans();
    Random rand = new Random();
    Console.Write("start");
    foreach (Schoolclass classPlan in Schoolclass.AllClasses)
    {
        foreach (Subject subject in classPlan.Curriculum)
        {
            bool placed = false;

            for (int d = 0; d < Days && !placed; d++)
            {
                for (int h = 0; h < Hours && !placed; h++)
                {
                    if (classPlan.ClassPlan[d, h] == null)
                    {
                        placed = false;
                        int attempts = 0;
                        int maxAttempts = 50;

                        while (attempts < maxAttempts && !placed)
                        {
                            Teacher t = Teacher.AllTeachers[rand.Next(Teacher.AllTeachers.Count)];
                            Room r = Room.AllRooms[rand.Next(Room.AllRooms.Count)];

                            if (t.TeacherPlan[d, h] == null
                                && t.Availability[d, h] == true
                                && r.RoomPlan[d, h] == null)
                            {

                                TimetableSlot slot = new TimetableSlot(t, subject, r, classPlan, d, h);

                                classPlan.ClassPlan[d, h] = slot;
                                t.TeacherPlan[d, h] = slot;
                                r.RoomPlan[d, h] = slot;

                                placed = true;
                            }
                            attempts++;
                        }

                        if (!placed)
                        {
                            Console.WriteLine($"Warning: {subject} couldn't be add to the Class {classPlan.Abbreviation}.");
                        }
                    }
                }
            }
        }
    }
            Console.Write("beendung erst erstellung");
            Optimizer.Optimise();
}
public static void ClearAllPlans()
{
    foreach (Schoolclass schoolClass in Schoolclass.AllClasses)
    {
        schoolClass.ClassPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];
    }

    foreach (Teacher teacher in Teacher.AllTeachers)
    {
        teacher.TeacherPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];
    }

    foreach (Room room in Room.AllRooms)
    {
        room.RoomPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];
    }
}
    }
}
