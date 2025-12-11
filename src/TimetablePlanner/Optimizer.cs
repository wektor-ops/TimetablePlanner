using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    public class Optimizer
    {
        public static void Optimise()
        {
            IScheduleEvaluator evaluator = new Evaluator();
            List<Schoolclass> currentPlan = DeepCloneClasses(Schoolclass.AllClasses);
            int currentScore = evaluator.Evaluate(currentPlan);
            bool foundBetterGlobal = true;
            while (foundBetterGlobal)
            {
                foundBetterGlobal = false;
                int bestNeighborScore = currentScore;
                List<Schoolclass> bestNeighborPlan = null;


                int numClasses = currentPlan.Count;

                for (int c = 0; c < numClasses; c++)
                {
                    for (int d1 = 0; d1 < Timetable.Days; d1++)
                        for (int h1 = 0; h1 < Timetable.Hours; h1++)
                        {
                            for (int d2 = 0; d2 < Timetable.Days; d2++)
                                for (int h2 = 0; h2 < Timetable.Hours; h2++)
                                {
                                    if (d1 == d2 && h1 == h2) continue;


                                    TimetableSlot slot1 = currentPlan[c].ClassPlan[d1, h1];
                                    TimetableSlot slot2 = currentPlan[c].ClassPlan[d2, h2];
                                    if (IsSwapValid(currentPlan, c, d1, h1, d2, h2))
                                    {
                                        List<Schoolclass> neighborPlan = DeepCloneClasses(currentPlan);
                                        SwapSlots(neighborPlan[c], d1, h1, d2, h2);
                                        RecalculateResourcePlans(neighborPlan);

                                        int neighborScore = evaluator.Evaluate(neighborPlan);

                                        if (neighborScore > bestNeighborScore)
                                        {
                                            bestNeighborScore = neighborScore;
                                            bestNeighborPlan = neighborPlan;
                                            foundBetterGlobal = true;
                                        }
                                    }

                                }
                        }
                }
                if (foundBetterGlobal)
                {
                    RecalculateResourcePlans(bestNeighborPlan);
                    Schoolclass.AllClasses = bestNeighborPlan;
                    currentPlan = bestNeighborPlan;
                    currentScore = bestNeighborScore;
                }
            }
        }

        private static void SwapSlots(Schoolclass classToModify, int d1, int h1, int d2, int h2)
        {
 
            TimetableSlot temp = classToModify.ClassPlan[d1, h1];
            classToModify.ClassPlan[d1, h1] = classToModify.ClassPlan[d2, h2];
            classToModify.ClassPlan[d2, h2] = temp;

            if (classToModify.ClassPlan[d1, h1] != null)
            {
                classToModify.ClassPlan[d1, h1].day = d1;
                classToModify.ClassPlan[d1, h1].hour = h1;
            }
            if (classToModify.ClassPlan[d2, h2] != null)
            {
                classToModify.ClassPlan[d2, h2].day = d2;
                classToModify.ClassPlan[d2, h2].hour = h2;
            }
        }
        public static bool IsSwapValid(List<Schoolclass> currentPlan, int c, int d1, int h1, int d2, int h2)
        {
            TimetableSlot slot1 = currentPlan[c].ClassPlan[d1, h1];
            TimetableSlot slot2 = currentPlan[c].ClassPlan[d2, h2];


            Teacher t1 = slot1?.assignedTeacher;
            Room r1 = slot1?.assignedRoom;

            Teacher t2 = slot2?.assignedTeacher;
            Room r2 = slot2?.assignedRoom;

            if (slot1 != null)
            {
                if (IsResourceOccupiedByOtherClass(currentPlan, c, t1, r1, d2, h2))
                    return false;
            }

            if (slot2 != null)
            {
                if (IsResourceOccupiedByOtherClass(currentPlan, c, t2, r2, d1, h1))
                    return false;
            }

            if ((t1 != null && t1.Availability[d2, h2] == false) ||
                (t2 != null && t2.Availability[d1, h1] == false))
            {
                return false;
            }

            return true;
        }
        private static bool IsResourceOccupiedByOtherClass(List<Schoolclass> globalPlan, int classIndexToIgnore, Teacher t, Room r, int d, int h)
        {
            if (t != null && t.Availability[d, h] == false)
                return true;

            for (int i = 0; i < globalPlan.Count; i++)
            {
                if (i == classIndexToIgnore) continue;

                TimetableSlot otherSlot = globalPlan[i].ClassPlan[d, h];

                if (otherSlot != null)
                {
                    if (t != null && otherSlot.assignedTeacher == t)
                        return true;

                    if (r != null && otherSlot.assignedRoom == r)
                        return true;
                }
            }
            return false;
        }
        public static void RecalculateResourcePlans(List<Schoolclass> plan)
        {

            foreach (var teacher in Teacher.AllTeachers)
            {
                teacher.TeacherPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];
            }

            foreach (var room in Room.AllRooms)
            {
                room.RoomPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];
            }


            foreach (Schoolclass schoolClass in plan)
            {
                for (int d = 0; d < Timetable.Days; d++)
                {
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        TimetableSlot slot = schoolClass.ClassPlan[d, h];

                        if (slot != null)
                        {

                            slot.assignedTeacher.TeacherPlan[d, h] = slot;
                            slot.assignedRoom.RoomPlan[d, h] = slot;
                        }
                    }
                }
            }
        }

        private static List<Schoolclass> DeepCloneClasses(List<Schoolclass> source)
        {
            List<Schoolclass> newList = new List<Schoolclass>();
            foreach (Schoolclass sc in source)
            {
                newList.Add(sc.Clone());
            }
            return newList;
        }

    }
}