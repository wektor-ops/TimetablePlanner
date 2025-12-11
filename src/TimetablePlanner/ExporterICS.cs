using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner 
{
    internal class ExporterICS : IScheduleExporter
    {
        public void ExportStudentPlan(Schoolclass schoolclass)
        {
            List<TimetableSlot> slots = new List<TimetableSlot>();

            if (schoolclass.ClassPlan != null)
            {
                for (int day = 0; day < Timetable.Days; day++)
                {
                    for (int hour = 0; hour < Timetable.Hours; hour++)
                    {
                        TimetableSlot slot = schoolclass.ClassPlan[day, hour];
                        if (slot != null)
                        {
                            slots.Add(slot);
                        }
                    }
                }
            }

            List<string> icsEvents = new List<string>();
            DateTime today = DateTime.Today;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime baseMonday = today.AddDays(daysUntilMonday);

            foreach (TimetableSlot slot in slots)
            {
                DateTime lessonDay;
                switch (slot.day)
                {
                    case 0: 
                        lessonDay = baseMonday;
                        break;
                    case 1:
                        lessonDay = baseMonday.AddDays(1);
                        break;
                    case 2:
                        lessonDay = baseMonday.AddDays(2);
                        break;
                    case 3:
                        lessonDay = baseMonday.AddDays(3);
                        break;
                    case 4: 
                        lessonDay = baseMonday.AddDays(4);
                        break;
                    default:
                        lessonDay = baseMonday;
                        break;
                }

                TimeSpan startTime;
                switch (slot.hour)
                {
                    case 0:
                        startTime = new TimeSpan(8, 0, 0);
                        break;
                    case 1:
                        startTime = new TimeSpan(9, 0, 0);
                        break;
                    case 2:
                        startTime = new TimeSpan(10, 0, 0);
                        break;
                    case 3:
                        startTime = new TimeSpan(11, 0, 0);
                        break;
                    case 4:
                        startTime = new TimeSpan(13, 0, 0);
                        break;
                    case 5:
                        startTime = new TimeSpan(14, 0, 0);
                        break;
                    case 6:
                        startTime = new TimeSpan(15, 0, 0);
                        break;
                    case 7:
                        startTime = new TimeSpan(16, 0, 0);
                        break;
                    default:
                        startTime = TimeSpan.Zero;
                        break;
                }
                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(60));

                // --- ICS Event Block ---
                icsEvents.Add("BEGIN:VEVENT");
                icsEvents.Add($"UID:{Guid.NewGuid():N}");
                icsEvents.Add($"DTSTAMP:{DateTime.UtcNow:yyyyMMddTHHmmssZ}");
                icsEvents.Add($"DTSTART;TZID=Europe/Zurich:{lessonDay.Date.Add(startTime):yyyyMMddTHHmmss}");
                icsEvents.Add($"DTEND;TZID=Europe/Zurich:{lessonDay.Date.Add(endTime):yyyyMMddTHHmmss}");

                icsEvents.Add($"SUMMARY:{slot.assignedSubject.Abbreviation}");

                icsEvents.Add($"DESCRIPTION: Teacher: {slot.assignedTeacher.Abbreviation} Room: {slot.assignedRoom.Abbreviation}");

                icsEvents.Add("END:VEVENT");
            }


            string fileName = $"Timetable_Class_{schoolclass.Abbreviation}.ics";
            string title = $"Timetable Class {schoolclass.Abbreviation}";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine($"PRODID:-//TimetablePlanner//{title}//EN");

            foreach (string eventEntry in icsEvents)
            {
                sb.AppendLine(eventEntry);
            }

            sb.AppendLine("END:VCALENDAR");

            // Saves the Timetable on to the Desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);
            File.WriteAllText(filePath, sb.ToString());

        }
        public void ExportTeacherPlan(Teacher teacher)
        {
            List<TimetableSlot> slots = new List<TimetableSlot>();

            if (teacher.TeacherPlan != null)
            {
                for (int day = 0; day < Timetable.Days; day++)
                {
                    for (int hour = 0; hour < Timetable.Hours; hour++)
                    {
                        TimetableSlot slot = teacher.TeacherPlan[day, hour];
                        if (slot != null)
                        {
                            slots.Add(slot);
                        }
                    }
                }
            }
            List<string> icsEvents = new List<string>();
            DateTime today = DateTime.Today;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime baseMonday = today.AddDays(daysUntilMonday);

            foreach (TimetableSlot slot in slots)
            {
                DateTime lessonDay;
                switch (slot.day)
                {
                    case 0:
                        lessonDay = baseMonday;
                        break;
                    case 1:
                        lessonDay = baseMonday.AddDays(1);
                        break;
                    case 2:
                        lessonDay = baseMonday.AddDays(2);
                        break;
                    case 3:
                        lessonDay = baseMonday.AddDays(3);
                        break;
                    case 4:
                        lessonDay = baseMonday.AddDays(4);
                        break;
                    default:
                        lessonDay = baseMonday;
                        break;
                }

                TimeSpan startTime;
                switch (slot.hour)
                {
                    case 0:
                        startTime = new TimeSpan(8, 0, 0);
                        break;
                    case 1:
                        startTime = new TimeSpan(9, 0, 0);
                        break;
                    case 2:
                        startTime = new TimeSpan(10, 0, 0);
                        break;
                    case 3:
                        startTime = new TimeSpan(11, 0, 0);
                        break;
                    case 4:
                        startTime = new TimeSpan(13, 0, 0);
                        break;
                    case 5:
                        startTime = new TimeSpan(14, 0, 0);
                        break;
                    case 6:
                        startTime = new TimeSpan(15, 0, 0);
                        break;
                    case 7:
                        startTime = new TimeSpan(16, 0, 0);
                        break;
                    default:
                        startTime = TimeSpan.Zero;
                        break;
                }
                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(60));

                // --- ICS Event Block ---
                icsEvents.Add("BEGIN:VEVENT");
                icsEvents.Add($"UID:{Guid.NewGuid():N}");
                icsEvents.Add($"DTSTAMP:{DateTime.UtcNow:yyyyMMddTHHmmssZ}");
                icsEvents.Add($"DTSTART;TZID=Europe/Zurich:{lessonDay.Date.Add(startTime):yyyyMMddTHHmmss}");
                icsEvents.Add($"DTEND;TZID=Europe/Zurich:{lessonDay.Date.Add(endTime):yyyyMMddTHHmmss}");

                icsEvents.Add($"SUMMARY:{slot.assignedSchoolclass.Abbreviation}");

                string descriptionValue = $"";
                icsEvents.Add($"DESCRIPTION: Subject: {slot.assignedSubject.Abbreviation} Room: {slot.assignedRoom.Abbreviation}");

                icsEvents.Add("END:VEVENT");
            }

            string fileName = $"Timetable_Teacher_{teacher.Abbreviation}.ics";
            string title = $"Timetable Teacher {teacher.Abbreviation}";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine($"PRODID:-//TimetablePlanner//{title}//EN");

            foreach (string eventEntry in icsEvents)
            {
                sb.AppendLine(eventEntry);
            }

            sb.AppendLine("END:VCALENDAR");

            // Saves the Timetable on to the Desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);
            File.WriteAllText(filePath, sb.ToString());
        }
        public void ExportRoomPlan(Room room)
        {
            List<TimetableSlot> slots = new List<TimetableSlot>();

            if (room.RoomPlan != null)
            {
                for (int day = 0; day < Timetable.Days; day++)
                {
                    for (int hour = 0; hour < Timetable.Hours; hour++)
                    {
                        TimetableSlot slot = room.RoomPlan[day, hour];
                        if (slot != null)
                        {
                            slots.Add(slot);
                        }
                    }
                }
            }
            List<string> icsEvents = new List<string>();
            DateTime today = DateTime.Today;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
            DateTime baseMonday = today.AddDays(daysUntilMonday);

            foreach (TimetableSlot slot in slots)
            {
                DateTime lessonDay;
                switch (slot.day)
                {
                    case 0:
                        lessonDay = baseMonday;
                        break;
                    case 1:
                        lessonDay = baseMonday.AddDays(1);
                        break;
                    case 2:
                        lessonDay = baseMonday.AddDays(2);
                        break;
                    case 3:
                        lessonDay = baseMonday.AddDays(3);
                        break;
                    case 4:
                        lessonDay = baseMonday.AddDays(4);
                        break;
                    default:
                        lessonDay = baseMonday;
                        break;
                }

                TimeSpan startTime;
                switch (slot.hour)
                {
                    case 0:
                        startTime = new TimeSpan(8, 0, 0);
                        break;
                    case 1:
                        startTime = new TimeSpan(9, 0, 0);
                        break;
                    case 2:
                        startTime = new TimeSpan(10, 0, 0);
                        break;
                    case 3:
                        startTime = new TimeSpan(11, 0, 0);
                        break;
                    case 4:
                        startTime = new TimeSpan(13, 0, 0);
                        break;
                    case 5:
                        startTime = new TimeSpan(14, 0, 0);
                        break;
                    case 6:
                        startTime = new TimeSpan(15, 0, 0);
                        break;
                    case 7:
                        startTime = new TimeSpan(16, 0, 0);
                        break;
                    default:
                        startTime = TimeSpan.Zero;
                        break;
                }
                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(60));

                // --- ICS Event Block ---
                icsEvents.Add("BEGIN:VEVENT");
                icsEvents.Add($"UID:{Guid.NewGuid():N}");
                icsEvents.Add($"DTSTAMP:{DateTime.UtcNow:yyyyMMddTHHmmssZ}");
                icsEvents.Add($"DTSTART;TZID=Europe/Zurich:{lessonDay.Date.Add(startTime):yyyyMMddTHHmmss}");
                icsEvents.Add($"DTEND;TZID=Europe/Zurich:{lessonDay.Date.Add(endTime):yyyyMMddTHHmmss}");

                icsEvents.Add($"SUMMARY:{slot.assignedSchoolclass.Abbreviation}");

                string descriptionValue = $"";
                icsEvents.Add($"DESCRIPTION: Subject: {slot.assignedSubject.Abbreviation} Teacher: {slot.assignedTeacher.Abbreviation}");

                icsEvents.Add("END:VEVENT");
            }

            string fileName = $"Timetable_Room_{room.Abbreviation}.ics";
            string title = $"Timetable Room {room.Abbreviation}";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine($"PRODID:-//TimetablePlanner//{title}//EN");

            foreach (string eventEntry in icsEvents)
            {
                sb.AppendLine(eventEntry);
            }

            sb.AppendLine("END:VCALENDAR");

            // Saves the Timetable on to the Desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
