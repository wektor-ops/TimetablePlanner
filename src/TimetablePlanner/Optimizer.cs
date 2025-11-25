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
        private Random _rand = new Random();
        private int _maxIterations;
        private double _startTemperature;
        private double _endTemperature;

        public Optimizer(int maxIterations = 20000, double startTemp = 1.0, double endTemp = 0.0001)
        {
            _maxIterations = maxIterations;
            _startTemperature = startTemp;
            _endTemperature = endTemp;
        }
       
        /// <summary>
        /// Hauptmethode: gibt die beste gefundene Welt zurück (kopie).
        /// Die übergebene world bleibt unverändert.
        /// </summary>
        public TimetableWorld Optimize(TimetableWorld world)
        {
            // Initiale Kopie und Bewertung
            var bestWorld = DeepCloneWorld(world);
            int bestScore = Evaluator.Evaluate(bestWorld);

            var currentWorld = DeepCloneWorld(bestWorld);
            int currentScore = bestScore;

            for (int iter = 0; iter < _maxIterations; iter++)
            {
                double tFrac = iter / (double)Math.Max(1, _maxIterations - 1);
                double temperature = _startTemperature * Math.Pow(_endTemperature / _startTemperature, tFrac);

                // Wähle Mutation
                string mutation = PickMutation();

                // Arbeite auf einer Kopie der aktuellen Welt
                var candidateWorld = DeepCloneWorld(currentWorld);

                bool changed = false;

                if (mutation == "SwapSlots")
                {
                    changed = MutateSwapSlots(candidateWorld);
                }
                else if (mutation == "MoveSlot")
                {
                    changed = MutateMoveSlot(candidateWorld);
                }
                else if (mutation == "ChangeRoom")
                {
                    changed = MutateChangeRoom(candidateWorld);
                }
                else if (mutation == "ChangeTeacher")
                {
                    changed = MutateChangeTeacher(candidateWorld);
                }
                else if (mutation == "BigShake")
                {
                    changed = MutateBigShake(candidateWorld);
                }
                else
                {
                    changed = false;
                }

                if (!changed)
                    continue; // nichts probiert / nichts verändert -> nächste Iteration

                int candidateScore = Evaluator.Evaluate(candidateWorld);

                // Akzeptanzregel: Greedy oder probabilistisch (Simulated Annealing)
                if (candidateScore > currentScore ||
                    AcceptWorse(candidateScore, currentScore, temperature))
                {
                    // Übernehme candidate als current
                    currentWorld = candidateWorld;
                    currentScore = candidateScore;

                    // Wenn besser als Best -> update Best
                    if (candidateScore > bestScore)
                    {
                        bestWorld = DeepCloneWorld(candidateWorld);
                        bestScore = candidateScore;
                        // Optional: log
                        // Console.WriteLine($"New best {bestScore} at iter {iter} via {mutation}");
                    }
                }

                // optional early stop if perfect (define what perfect means for you)
            }

            // Rückgabe der besten gefundene Welt (Kopie)
            return bestWorld;
        }

        private bool AcceptWorse(int candidateScore, int currentScore, double temperature)
        {
            if (candidateScore >= currentScore) return true;
            // Temperatur-basierte Akzeptanz
            double diff = candidateScore - currentScore; // negativ
            double prob = Math.Exp(diff / Math.Max(1e-9, temperature));
            return _rand.NextDouble() < prob;
        }
        // ------------------------------
        // --- MUTATIONEN (in-place) ---
        // ------------------------------

        /// <summary>
        /// Tauscht zwei belegte Slots zwischen (möglichst) verschiedenen Klassen/Zeiten.
        /// Führt Prüfen durch: Lehrer/Room-Freiheit berücksichtigen (kein stilles Überschreiben).
        /// </summary>
        private bool SwapSlots(TimetableWorld world)
        {
            // Sammle alle belegten Slots (classPlan, day, hour)
            var occupied = new List<(ClassTimetable classPlan, int d, int h)>();
            foreach (var cp in world.ClassPlans)
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                        if (cp.Slots[d, h] != null)
                            occupied.Add((cp, d, h));

            if (occupied.Count < 2) return false;

            // Versuche ein Paar zu finden (mit max attempts)
            int maxAttempts = Math.Min(occupied.Count * 2, 200);
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                var a = occupied[_rand.Next(occupied.Count)];
                var b = occupied[_rand.Next(occupied.Count)];
                if (a.classPlan == b.classPlan && a.d == b.d && a.h == b.h) continue;

                // Prüfe, ob swap möglich ohne Überschreiben:
                var slotA = a.classPlan.Slots[a.d, a.h];
                var slotB = b.classPlan.Slots[b.d, b.h];

                if (CanSwapSlots(world, a, b))
                {
                    PerformSwap(world, a, b);
                    return true;
                }
            }

            return false;
        }

        private bool CanSwapSlots(TimetableWorld world, (ClassTimetable classPlan, int d, int h) a, (ClassTimetable classPlan, int d, int h) b)
        {
            var slotA = a.classPlan.Slots[a.d, a.h];
            var slotB = b.classPlan.Slots[b.d, b.h];

            // Zielposition A will contain slotB: need teacherB and roomB free at (a.d,a.h),
            // unless the occupying entity is exactly slotA or slotB (swap pair).
            var teacherBPlan = world.TeacherPlans.First(tp => tp.Teacher == slotB.assignedTeacher);
            var roomBPlan = world.RoomPlans.First(rp => rp.Room == slotB.assignedRoom);
            var teacherAPlan = world.TeacherPlans.First(tp => tp.Teacher == slotA.assignedTeacher);
            var roomAPlan = world.RoomPlans.First(rp => rp.Room == slotA.assignedRoom);

            // Check teacherB at A.pos: either null or equals slotA (if teacherB == teacherA)
            var teacherB_at_A = teacherBPlan.Slots[a.d, a.h];
            if (teacherB_at_A != null && teacherB_at_A != slotA) return false;

            // Check roomB at A.pos
            var roomB_at_A = roomBPlan.Slots[a.d, a.h];
            if (roomB_at_A != null && roomB_at_A != slotA) return false;

            // Check teacherA at B.pos
            var teacherA_at_B = teacherAPlan.Slots[b.d, b.h];
            if (teacherA_at_B != null && teacherA_at_B != slotB) return false;

            // Check roomA at B.pos
            var roomA_at_B = roomAPlan.Slots[b.d, b.h];
            if (roomA_at_B != null && roomA_at_B != slotB) return false;

            // Optional: check teacher availability if defined
            if (!TeacherAvailableAt(slotA.assignedTeacher, b.d, b.h)) return false; // normal machen
            if (!TeacherAvailableAt(slotB.assignedTeacher, a.d, a.h)) return false; // normal machen

            return true;
        }

        private void PerformSwap(TimetableWorld world, (ClassTimetable classPlan, int d, int h) a, (ClassTimetable classPlan, int d, int h) b)
        {
            var slotA = a.classPlan.Slots[a.d, a.h];
            var slotB = b.classPlan.Slots[b.d, b.h];

            // Remove references from old teacher/room arrays (only if they point to these slots)
            var teacherAPlan = world.TeacherPlans.First(tp => tp.Teacher == slotA.assignedTeacher);
            var roomAPlan = world.RoomPlans.First(rp => rp.Room == slotA.assignedRoom);
            var teacherBPlan = world.TeacherPlans.First(tp => tp.Teacher == slotB.assignedTeacher);
            var roomBPlan = world.RoomPlans.First(rp => rp.Room == slotB.assignedRoom);

            // Clear positions where applicable
            if (teacherAPlan.Slots[b.d, b.h] == slotA) teacherAPlan.Slots[b.d, b.h] = null;
            if (roomAPlan.Slots[b.d, b.h] == slotA) roomAPlan.Slots[b.d, b.h] = null;
            if (teacherBPlan.Slots[a.d, a.h] == slotB) teacherBPlan.Slots[a.d, a.h] = null;
            if (roomBPlan.Slots[a.d, a.h] == slotB) roomBPlan.Slots[a.d, a.h] = null;

            // Swap day/hour metadata on slots
            slotA.day = b.d; slotA.hour = b.h;
            slotB.day = a.d; slotB.hour = a.h;

            // Place swapped slots into class plans
            a.classPlan.Slots[a.d, a.h] = slotB;
            b.classPlan.Slots[b.d, b.h] = slotA;

            // Update teacher and room plans to reference swapped slots
            teacherBPlan.Slots[a.d, a.h] = slotB;
            roomBPlan.Slots[a.d, a.h] = slotB;

            teacherAPlan.Slots[b.d, b.h] = slotA;
            roomAPlan.Slots[b.d, b.h] = slotA;
        }

        /// <summary>
        /// Verschiebt eine Lektion einer Klasse in einen anderen freien Slot (innerhalb oder zwischen Tagen).
        /// </summary>
        private bool MoveSlot(TimetableWorld world)
        {
            // Wähle zufälligen belegten Slot
            var occupied = new List<(ClassTimetable cp, int d, int h)>();
            foreach (var cp in world.ClassPlans)
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                        if (cp.Slots[d, h] != null)
                            occupied.Add((cp, d, h));

            if (occupied.Count == 0) return false;

            var from = occupied[_rand.Next(occupied.Count)];
            var slot = from.cp.Slots[from.d, from.h];

            // Versuche freie Ziel-Positionen
            int maxAttempts = 200;
            for (int i = 0; i < maxAttempts; i++)
            {
                int td = _rand.Next(Timetable.Days);
                int th = _rand.Next(Timetable.Hours);

                if (from.cp.Slots[td, th] != null) continue; // Ziel besetzt

                // Prüfe Teacher & Room frei am Ziel (oder it's the same teacher/room if moving within same pos)
                var teacherPlan = world.TeacherPlans.First(tp => tp.Teacher == slot.assignedTeacher);
                var roomPlan = world.RoomPlans.First(rp => rp.Room == slot.assignedRoom);

                if (teacherPlan.Slots[td, th] != null) continue;
                if (roomPlan.Slots[td, th] != null) continue;
                if (!TeacherAvailableAt(slot.assignedTeacher, td, th)) continue; // normal machen

                // Move durchführen
                from.cp.Slots[from.d, from.h] = null;
                teacherPlan.Slots[from.d, from.h] = null;
                roomPlan.Slots[from.d, from.h] = null;

                slot.day = td; slot.hour = th;

                from.cp.Slots[td, th] = slot;
                teacherPlan.Slots[td, th] = slot;
                roomPlan.Slots[td, th] = slot;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Wechselt den Raum einer Lektion zu einem anderen freien Raum am selben Slot.
        /// </summary>
        private bool MutateChangeRoom(TimetableWorld world)
        {
            // Wähle zufälligen belegten Slot
            var occupied = new List<(ClassTimetable cp, int d, int h)>();
            foreach (var cp in world.ClassPlans)
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                        if (cp.Slots[d, h] != null)
                            occupied.Add((cp, d, h));

            if (occupied.Count == 0) return false;

            var sel = occupied[_rand.Next(occupied.Count)];
            var slot = sel.cp.Slots[sel.d, sel.h];

            // Suche alternativen Raum
            var candidateRooms = world.RoomPlans.Select(rp => rp.Room).OrderBy(r => _rand.Next()).ToList();
            foreach (var r in candidateRooms)
            {
                var rplan = world.RoomPlans.First(rp => rp.Room == r);
                if (rplan.Slots[sel.d, sel.h] == null)
                {
                    // perform change: clear old room reference, set new
                    var oldRoomPlan = world.RoomPlans.First(rp => rp.Room == slot.assignedRoom);
                    if (oldRoomPlan.Slots[sel.d, sel.h] == slot) oldRoomPlan.Slots[sel.d, sel.h] = null;

                    slot.assignedRoom = r;
                    rplan.Slots[sel.d, sel.h] = slot;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tauscht den Lehrer einer Lektion, sofern ein anderer verfügbar ist.
        /// </summary>
        private bool MutateChangeTeacher(TimetableWorld world)
        {
            // Wähle zufälligen belegten Slot
            var occupied = new List<(ClassTimetable cp, int d, int h)>();
            foreach (var cp in world.ClassPlans)
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                        if (cp.Slots[d, h] != null)
                            occupied.Add((cp, d, h));

            if (occupied.Count == 0) return false;

            var sel = occupied[_rand.Next(occupied.Count)];
            var slot = sel.cp.Slots[sel.d, sel.h];

            // Candidate teachers (random order)
            var candidates = world.TeacherPlans.Select(tp => tp.Teacher).OrderBy(t => _rand.Next()).ToList();
            foreach (var t in candidates)
            {
                if (t == slot.assignedTeacher) continue;

                var tplan = world.TeacherPlans.First(tp => tp.Teacher == t);
                // Check availability array (if exists) and free slot
                if (!TeacherAvailableAt(t, sel.d, sel.h)) continue; // normal machen
                if (tplan.Slots[sel.d, sel.h] != null) continue;

                // switch teacher: clear old teacher plan slot, set new
                var oldTPlan = world.TeacherPlans.First(tp => tp.Teacher == slot.assignedTeacher);
                if (oldTPlan.Slots[sel.d, sel.h] == slot) oldTPlan.Slots[sel.d, sel.h] = null;

                slot.assignedTeacher = t;
                tplan.Slots[sel.d, sel.h] = slot;
                return true;
            }

            return false;
        }

        // ------------------------------
        // --- Hilfsfunktionen ---
        // ------------------------------

        // Klonen der Welt: kopiert nur die Slot-Struktur tief, die Referenzen zu Teacher/Room/Class bleiben identisch.
        private TimetableWorld DeepCloneWorld(TimetableWorld src) // schauen ob wirklich nötig
        {
            var dst = new TimetableWorld();

            // Clone class plans
            foreach (var cp in src.ClassPlans)
            {
                var n = new ClassTimetable(cp.Class);
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        var s = cp.Slots[d, h];
                        if (s != null)
                        {
                            // create a shallow copy of TimetableSlot that references same real objects
                            var ns = new TimetableSlot(s.assignedTeacher, s.assignedSubject, s.assignedRoom, s.assignedSchoolclass, s.day, s.hour);
                            ns.day = s.day; ns.hour = s.hour;
                            n.Slots[d, h] = ns;
                        }
                    }
                dst.ClassPlans.Add(n);
            } 

            // Clone teacher plans
            foreach (var tp in src.TeacherPlans)
            {
                var nt = new TeacherTimetable(tp.Teacher);
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        var s = tp.Slots[d, h];
                        if (s != null)
                        {
                            // locate the corresponding new slot in dst.ClassPlans (by class + day,hour)
                            var targetClassPlan = dst.ClassPlans.First(cp => cp.Class == s.assignedSchoolclass);
                            var newSlot = targetClassPlan.Slots[d, h];
                            // newSlot may be null if class hasn't set it yet (order-dependent); if null, create placeholder
                            if (newSlot == null)
                            {
                                newSlot = new TimetableSlot(s.assignedTeacher, s.assignedSubject, s.assignedRoom, s.assignedSchoolclass, d, h);
                                targetClassPlan.Slots[d, h] = newSlot;
                            }
                            nt.Slots[d, h] = newSlot;
                        }
                    }
                dst.TeacherPlans.Add(nt);
            }

            // Clone room plans
            foreach (var rp in src.RoomPlans)
            {
                var nr = new RoomTimetable(rp.Room);
                for (int d = 0; d < Timetable.Days; d++)
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        var s = rp.Slots[d, h];
                        if (s != null)
                        {
                            var targetClassPlan = dst.ClassPlans.First(cp => cp.Class == s.assignedSchoolclass);
                            var newSlot = targetClassPlan.Slots[d, h];
                            if (newSlot == null)
                            {
                                newSlot = new TimetableSlot(s.assignedTeacher, s.assignedSubject, s.assignedRoom, s.assignedSchoolclass, d, h);
                                targetClassPlan.Slots[d, h] = newSlot;
                            }
                            nr.Slots[d, h] = newSlot;
                        }
                    }
                dst.RoomPlans.Add(nr);
            }

            return dst;
        }
    }

}