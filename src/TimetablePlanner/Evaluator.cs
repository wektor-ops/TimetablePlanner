using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    public class Evaluator : IScheduleEvaluator
    {
        public int Evaluate(List<Schoolclass> currentPlan)
        {
            int score = 0;

            foreach (Schoolclass classPlan in currentPlan)
            {
                score += ScoreClassPlan(classPlan);
            }
            return score;
        }

        private int ScoreClassPlan(Schoolclass plan)
        {
            int score = 0;

            score += ScoreGaps(plan);        
            score += ScoreRoomChanges(plan);        
            score += ScoreEdgeHours(plan);           
            score += ScoreResourceEfficiency();     

            return score;
        }

        private int ScoreGaps(Schoolclass plan)
        {
            int penalty = 0;

            for (int d = 0; d < Timetable.Days; d++)
            {
                TimetableSlot lastSeen = null;
                for (int h = 0; h < Timetable.Hours; h++)
                {
                    TimetableSlot slot = plan.ClassPlan[d, h];

                    if (slot != null)
                    {
                        if (lastSeen == null && h > 0)
                        {
                            for (int x = 0; x < h; x++)
                            {
                                if (plan.ClassPlan[d, x] == null)
                                {
                                    penalty -= Timetable.penalty_Gap; 
                                    break;
                                }
                            }
                        }
                        lastSeen = slot;
                    }
                }
            }

            return penalty;
        }

        private int ScoreRoomChanges(Schoolclass plan)
        {
            int penalty = 0;

            for (int d = 0; d < Timetable.Days; d++)
            {
                Room lastRoom = null;

                for (int h = 0; h < Timetable.Hours; h++)
                {
                    TimetableSlot slot = plan.ClassPlan[d, h];
                    if (slot == null) continue;

                    if (lastRoom != null && slot.assignedRoom != lastRoom)
                    {
                        penalty -= Timetable.penalty_RoomChange; 
                    }

                    lastRoom = slot.assignedRoom;
                }
            }

            return penalty;
        }

        private int ScoreEdgeHours(Schoolclass plan)
        {
            int penalty = 0;

            for (int d = 0; d < Timetable.Days; d++)
            {
                if (plan.ClassPlan[d, 0] != null)
                {
                    bool isolated = true;
                    for (int h = 1; h <= 2 && h < Timetable.Hours; h++)
                    {
                        if (plan.ClassPlan[d, h] != null)
                        {
                            isolated = false;
                            break;
                        }
                    }
                    if (isolated) penalty -= Timetable.penalty_EdgeHour;
                }

                int last = Timetable.Hours - 1;
                if (plan.ClassPlan[d, last] != null)
                {
                    bool isolated = true;
                    for (int h = last - 1; h >= last - 2 && h >= 0; h--)
                    {
                        if (plan.ClassPlan[d, h] != null)
                        {
                            isolated = false;
                            break;
                        }
                    }
                    if (isolated) penalty -= Timetable.penalty_EdgeHour;
                }
            }
            return penalty;
        }
        private int ScoreResourceEfficiency()
        {
            int score = 0;

            for (int d = 0; d < Timetable.Days; d++)
            {
                for (int h = 0; h < Timetable.Hours; h++)
                {
                    List<Room> usedRooms = new List<Room>();

                    foreach (Schoolclass classPlan in Schoolclass.AllClasses)
                    {
                        TimetableSlot slot = classPlan.ClassPlan[d, h];

                        if (slot != null && slot.assignedRoom != null)
                        {
                            usedRooms.Add(slot.assignedRoom);
                        }
                    }

                    int numUsedRooms = usedRooms.Distinct().Count();

                    if (numUsedRooms <= (int)Math.Round(Schoolclass.AllClasses.Count * 0.90, 0))
                    {
                        score += Timetable.penalty_RoomsUse;
                    }
                }
            }
            return score;
        }
    }
}
