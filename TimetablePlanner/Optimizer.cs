using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Optimizer
    {


    }
    // 6. InitialSolutionBuilder
    internal class FirstPlanBuilder
    {
        private TimetableWorld world;
        private List<Schoolclass> classes;
        private List<Teacher> teachers;
        private List<Room> rooms;

        public FirstPlanBuilder(List<Schoolclass> classes, List<Teacher> teachers, List<Room> rooms)
        {
            this.classes = classes;
            this.teachers = teachers;
            this.rooms = rooms;
            world = new TimetableWorld();

            // Leere Pläne anlegen
            foreach (var c in classes)
                world.ClassPlans.Add(new ClassTimetable(c));
            foreach (var t in teachers)
                world.TeacherPlans.Add(new TeacherTimetable(t));
            foreach (var r in rooms)
                world.RoomPlans.Add(new RoomTimetable(r));
        }

        public TimetableWorld Build()
        {
            Random rand = new Random();

            foreach (var classPlan in world.ClassPlans)
            {
                foreach (var subject in classPlan.Class.Curriculum)
                {
                    bool placed = false;

                    // Suche Tag/Hour
                    for (int d = 0; d < Timetable.Days && !placed; d++)
                    {
                        for (int h = 0; h < Timetable.Hours && !placed; h++)
                        {
                            if (classPlan.Slots[d, h] == null)
                            {
                                placed = false;
                                int attempts = 0;
                                int maxAttempts = 50; // Abbruch, falls kein freier Lehrer/Raum gefunden wird

                                while (attempts < maxAttempts && !placed)
                                {

                                    // Lehrer zufällig wählen (alle können alles)
                                    Teacher t = teachers[rand.Next(teachers.Count)];
                                    TeacherTimetable teacherPlan = world.TeacherPlans.First(tp => tp.Teacher == t);

                                    // Raum zufällig wählen
                                    Room r = rooms[rand.Next(rooms.Count)];
                                    RoomTimetable roomPlan = world.RoomPlans.First(rp => rp.Room == r);

                                    if (teacherPlan.Slots[d, h] == null
                                        && roomPlan.Slots[d, h] == null)
                                    {

                                        TimetableSlot slot = new TimetableSlot(t, subject, r, classPlan.Class, d, h);

                                        // Slot eintragen
                                        classPlan.Slots[d, h] = slot;
                                        teacherPlan.Slots[d, h] = slot;
                                        roomPlan.Slots[d, h] = slot;

                                        placed = true;
                                    }
                                }

                                if (!placed)
                                {
                                    // Notfall: wenn kein freier Slot gefunden → Warnung
                                    Console.WriteLine($"Warnung: {subject} konnte nicht für Klasse {classPlan.Class.Abbreviation} eingetragen werden.");
                                }
                            }
                        }
                    }
                }
            }
            return world;
        }



    }





}