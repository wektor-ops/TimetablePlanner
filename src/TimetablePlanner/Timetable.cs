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


        public static void OutputTimetableofClass(Schoolclass schoolClass)
        {

            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║       Mo       ║       Di       ║       Mi       ║       Do       ║       Fr       ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");

            // 08:00
            Console.WriteLine("║ 08:00  ║ " + schoolClass.ClassPlan[0, 0].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 0].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 0].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 0].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 0].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 0].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 0].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 0].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 0].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 0].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 0].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 0].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 0].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 0].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 0].assignedRoom.Abbreviation + " ║");

            // 09:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 09:00  ║ " + schoolClass.ClassPlan[0, 1].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 1].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 1].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 1].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 1].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 1].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 1].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 1].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 1].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 1].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 1].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 1].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 1].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 1].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 1].assignedRoom.Abbreviation + " ║");

            // 10:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 10:00  ║ " + schoolClass.ClassPlan[0, 2].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 2].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 2].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 2].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 2].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 2].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 2].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 2].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 2].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 2].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 2].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 2].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 2].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 2].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 2].assignedRoom.Abbreviation + " ║");

            // 11:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 11:00  ║ " + schoolClass.ClassPlan[0, 3].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 3].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 3].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 3].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 3].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 3].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 3].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 3].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 3].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 3].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 3].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 3].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 3].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 3].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 3].assignedRoom.Abbreviation + " ║");

            // 12:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 12:00  ║ " + schoolClass.ClassPlan[0, 4].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 4].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 4].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 4].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 4].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 4].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 4].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 4].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 4].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 4].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 4].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 4].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 4].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 4].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 4].assignedRoom.Abbreviation + " ║");

            // 13:00 (Pause)
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
            Console.WriteLine("║        ║                ║                ║                ║                ║                ║");

            // 14:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 14:00  ║ " + schoolClass.ClassPlan[0, 5].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 5].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 5].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 5].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 5].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 5].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 5].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 5].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 5].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 5].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 5].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 5].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 5].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 5].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 5].assignedRoom.Abbreviation + " ║");

            // 15:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00  ║ " + schoolClass.ClassPlan[0, 6].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 6].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 6].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 6].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 6].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 6].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 6].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 6].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 6].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 6].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 6].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 6].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 6].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 6].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 6].assignedRoom.Abbreviation + " ║");

            // 16:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00  ║ " + schoolClass.ClassPlan[0, 7].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 7].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 7].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 7].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 7].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 7].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 7].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 7].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 7].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 7].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 7].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 7].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 7].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 7].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 7].assignedRoom.Abbreviation + " ║");

            // 17:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 17:00  ║ " + schoolClass.ClassPlan[0, 8].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 8].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 8].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 8].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 8].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 8].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 8].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 8].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 8].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 8].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 8].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 8].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 8].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 8].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 8].assignedRoom.Abbreviation + " ║");

            // 18:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 18:00  ║ " + schoolClass.ClassPlan[0, 9].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[0, 9].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[1, 9].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[1, 9].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[2, 9].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[2, 9].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[3, 9].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[3, 9].assignedTeacher.Abbreviation + " ║ " +
                                                    schoolClass.ClassPlan[4, 9].assignedSubject.Abbreviation + " " + schoolClass.ClassPlan[4, 9].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + schoolClass.Abbreviation + " " + schoolClass.ClassPlan[0, 9].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[1, 9].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[2, 9].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[3, 9].assignedRoom.Abbreviation + " ║ " +
                                                    schoolClass.Abbreviation + " " + schoolClass.ClassPlan[4, 9].assignedRoom.Abbreviation + " ║");

            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");




        }
        public static void OutputTimetableofTeacher(Teacher teacher)
        {

            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║       Mo       ║       Di       ║       Mi       ║       Do       ║       Fr       ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");

            // 08:00
            Console.WriteLine("║ 08:00  ║ " + teacher.TeacherPlan[0, 0].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 0].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 0].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 0].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 0].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 0].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 0].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 0].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 0].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 0].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 0].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 0].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 0].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 0].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 0].assignedRoom.Abbreviation + " ║");

            // 09:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 09:00  ║ " + teacher.TeacherPlan[0, 1].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 1].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 1].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 1].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 1].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 1].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 1].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 1].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 1].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 1].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 1].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 1].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 1].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 1].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 1].assignedRoom.Abbreviation + " ║");

            // 10:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 10:00  ║ " + teacher.TeacherPlan[0, 2].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 2].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 2].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 2].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 2].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 2].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 2].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 2].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 2].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 2].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 2].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 2].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 2].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 2].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 2].assignedRoom.Abbreviation + " ║");

            // 11:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 11:00  ║ " + teacher.TeacherPlan[0, 3].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 3].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 3].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 3].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 3].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 3].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 3].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 3].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 3].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 3].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 3].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 3].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 3].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 3].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 3].assignedRoom.Abbreviation + " ║");

            // 12:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 12:00  ║ " + teacher.TeacherPlan[0, 4].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 4].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 4].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 4].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 4].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 4].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 4].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 4].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 4].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 4].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 4].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 4].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 4].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 4].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 4].assignedRoom.Abbreviation + " ║");

            // 13:00 (Pause)
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
            Console.WriteLine("║        ║                ║                ║                ║                ║                ║");

            // 14:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 14:00  ║ " + teacher.TeacherPlan[0, 5].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 5].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 5].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 5].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 5].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 5].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 5].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 5].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 5].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 5].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 5].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 5].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 5].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 5].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 5].assignedRoom.Abbreviation + " ║");

            // 15:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00  ║ " + teacher.TeacherPlan[0, 6].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 6].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 6].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 6].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 6].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 6].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 6].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 6].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 6].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 6].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 6].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 6].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 6].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 6].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 6].assignedRoom.Abbreviation + " ║");

            // 16:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00  ║ " + teacher.TeacherPlan[0, 7].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 7].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 7].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 7].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 7].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 7].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 7].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 7].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 7].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 7].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 7].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 7].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 7].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 7].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 7].assignedRoom.Abbreviation + " ║");

            // 17:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 17:00  ║ " + teacher.TeacherPlan[0, 8].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 8].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 8].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 8].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 8].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 8].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 8].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 8].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 8].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 8].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 8].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 8].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 8].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 8].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 8].assignedRoom.Abbreviation + " ║");

            // 18:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 18:00  ║ " + teacher.TeacherPlan[0, 9].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[0, 9].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[1, 9].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[1, 9].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[2, 9].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[2, 9].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[3, 9].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[3, 9].assignedTeacher.Abbreviation + " ║ " +
                                               teacher.TeacherPlan[4, 9].assignedSubject.Abbreviation + " " + teacher.TeacherPlan[4, 9].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║        ║ " + teacher.Abbreviation + " " + teacher.TeacherPlan[0, 9].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[1, 9].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[2, 9].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[3, 9].assignedRoom.Abbreviation + " ║ " +
                                               teacher.Abbreviation + " " + teacher.TeacherPlan[4, 9].assignedRoom.Abbreviation + " ║");

            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");



        }



        public static void OutputTimetableofRoom(Room Room)
        {

            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║ Zeit   ║ Mo             ║ Di             ║ Mi             ║ Do             ║ Fr             ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");

            // 08:00
            Console.WriteLine("║ 08:00 ║ " + Room.RoomPlan[0, 0].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 0].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 0].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 0].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 0].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 0].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 0].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 0].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 0].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 0].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 0].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 0].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 0].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 0].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 0].assignedRoom.Abbreviation + " ║");

            // 09:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 09:00 ║ " + Room.RoomPlan[0, 1].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 1].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 1].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 1].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 1].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 1].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 1].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 1].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 1].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 1].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 1].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 1].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 1].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 1].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 1].assignedRoom.Abbreviation + " ║");

            // 10:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 10:00 ║ " + Room.RoomPlan[0, 2].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 2].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 2].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 2].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 2].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 2].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 2].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 2].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 2].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 2].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 2].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 2].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 2].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 2].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 2].assignedRoom.Abbreviation + " ║");

            // 11:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 11:00 ║ " + Room.RoomPlan[0, 3].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 3].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 3].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 3].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 3].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 3].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 3].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 3].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 3].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 3].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 3].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 3].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 3].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 3].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 3].assignedRoom.Abbreviation + " ║");

            // 12:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 12:00 ║ " + Room.RoomPlan[0, 4].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 4].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 4].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 4].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 4].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 4].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 4].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 4].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 4].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 4].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 4].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 4].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 4].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 4].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 4].assignedRoom.Abbreviation + " ║");

            // 13:00 Pause
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 13:00 ║ ║ ║ ║ ║ ║");
            Console.WriteLine("║      ║ ║ ║ ║ ║ ║");

            // 14:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 14:00 ║ " + Room.RoomPlan[0, 5].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 5].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 5].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 5].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 5].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 5].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 5].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 5].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 5].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 5].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 5].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 5].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 5].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 5].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 5].assignedRoom.Abbreviation + " ║");

            // 15:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00 ║ " + Room.RoomPlan[0, 6].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 6].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 6].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 6].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 6].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 6].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 6].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 6].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 6].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 6].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 6].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 6].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 6].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 6].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 6].assignedRoom.Abbreviation + " ║");

            // 16:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00 ║ " + Room.RoomPlan[0, 7].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 7].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 7].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 7].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 7].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 7].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 7].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 7].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 7].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 7].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 7].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 7].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 7].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 7].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 7].assignedRoom.Abbreviation + " ║");

            // 17:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 17:00 ║ " + Room.RoomPlan[0, 8].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 8].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 8].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 8].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 8].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 8].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 8].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 8].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 8].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 8].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 8].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 8].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 8].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 8].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 8].assignedRoom.Abbreviation + " ║");

            // 18:00
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 18:00 ║ " + Room.RoomPlan[0, 9].assignedSubject.Abbreviation + " " + Room.RoomPlan[0, 9].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[1, 9].assignedSubject.Abbreviation + " " + Room.RoomPlan[1, 9].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[2, 9].assignedSubject.Abbreviation + " " + Room.RoomPlan[2, 9].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[3, 9].assignedSubject.Abbreviation + " " + Room.RoomPlan[3, 9].assignedTeacher.Abbreviation + " ║ " + Room.RoomPlan[4, 9].assignedSubject.Abbreviation + " " + Room.RoomPlan[4, 9].assignedTeacher.Abbreviation + " ║");
            Console.WriteLine("║      ║ " + Room.Abbreviation + " " + Room.RoomPlan[0, 9].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[1, 9].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[2, 9].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[3, 9].assignedRoom.Abbreviation + " ║ " + Room.Abbreviation + " " + Room.RoomPlan[4, 9].assignedRoom.Abbreviation + " ║");

            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");






        }

public static void Build()
{
    Random rand = new Random();

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
