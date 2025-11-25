using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal static class Evaluator
    {
        public static int Evaluate()
        {
            int score = 0;

            foreach (Schoolclass classPlan in Schoolclass.AllClasses)
            {
                score += ScoreClassPlan(classPlan);
            }
            return score;
        }

        // --------------------------------------------------------------------
        // CLASS SCORE
        // --------------------------------------------------------------------
        private static int ScoreClassPlan(Schoolclass plan)
        {
            int score = 0;

            score += ScoreGaps(plan);                 // -5 pro Lücke
            score += ScoreRoomChanges(plan);          // -2 pro Raumwechsel
            score += ScoreEdgeHours(plan);            // -5 für unnötige Randstunden
            score += ScoreResourceEfficiency();       // +- 4 für effiziernte Raum nutzung

            return score;
        }

        // Gaps inside the day: X - X  = 1 gap
        private static int ScoreGaps(Schoolclass plan)
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
                            // check if there was at least 1 hour with null between
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

        // Room changes: if consecutive slots have different Rooms
        private static int ScoreRoomChanges(Schoolclass plan)
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

        // Bad edge hours: isolated first or last lesson
        private static int ScoreEdgeHours(Schoolclass plan)
        {
            int penalty = 0;

            for (int d = 0; d < Timetable.Days; d++)
            {
                // first hour
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

                // last hour
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
        // Evaluates the overall timetable solution regarding resource usage (Rooms)
        private static int ScoreResourceEfficiency()
        {
            int score = 0;

            // Iteriere durch alle Tage und Stunden
            for (int d = 0; d < Timetable.Days; d++)
            {
                for (int h = 0; h < Timetable.Hours; h++)
                {
                    // Liste, um die belegten Räume in diesem Zeitschlitz zu verfolgen
                    List<Room> usedRooms = new List<Room>();

                    // 1. Alle Räume im aktuellen Zeitschlitz (d, h) sammeln
                    foreach (Schoolclass classPlan in Schoolclass.AllClasses)
                    {
                        TimetableSlot slot = classPlan.ClassPlan[d, h];

                        if (slot != null && slot.assignedRoom != null)
                        {
                            // Füge den Raum einfach zur Liste hinzu
                            usedRooms.Add(slot.assignedRoom);
                        }
                    }

                    // 2. Doppelte Einträge entfernen, um die Anzahl der EINDEUTIG genutzten Räume zu erhalten
                    // Hierfür verwenden wir Linq: Die distinct-Methode liefert eine Liste OHNE Duplikate.
                    // Der ursprüngliche Vorschlag mit HashSet ist hier performanter, 
                    // aber diese Version ist ebenfalls technisch korrekt.
                    int numUsedRooms = usedRooms.Distinct().Count();

                    // 3. Bewertung der Raumeffizienz

                    // ANNAHME: Wir belohnen, wenn die Auslastung unter einem 90% Schwellenwert liegt.
                    if (numUsedRooms <= (int)Math.Round(Schoolclass.AllClasses.Count * 0.90, 0))
                    {
                        // Belohnung für eine effiziente Nutzung
                        score += Timetable.penalty_RoomsUse;
                    }
                    else
                    {
                        // Optional: Leichte Strafe, wenn zu viele Räume gleichzeitig belegt sind
                        score -= Timetable.penalty_RoomsUse;
                    }
                }
            }
            return score;
        }
    }
}
