using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class JsonDatamanager : IDataManager
    {
        private const string FILE_PATH = "timetable_data.json";
        public void LoadData() 
        {
            if (!File.Exists(FILE_PATH))
                return;

            try
            {
                string jsonString = File.ReadAllText(FILE_PATH);
                TimetableData loadedData = JsonSerializer.Deserialize<TimetableData>(jsonString);

                if (loadedData != null)
                {
                    Schoolclass.AllClasses = loadedData.AllClasses ?? new List<Schoolclass>();
                    Teacher.AllTeachers = loadedData.AllTeachers ?? new List<Teacher>();
                    Room.AllRooms = loadedData.AllRooms ?? new List<Room>();
                    Subject.AllSubjects = loadedData.AllSubjects ?? new List<Subject>();

                    if (loadedData.AllPlans?.ClassPlans != null)
                    {
                        for (int i = 0; i < Schoolclass.AllClasses.Count; i++)
                        {
                            if (i < loadedData.AllPlans.ClassPlans.Count)
                            {
                                Schoolclass currentClass = Schoolclass.AllClasses[i];
                                TimetableSlot[][] loadedJaggedPlan = loadedData.AllPlans.ClassPlans[i];

                                // 2D Array initialisieren
                                currentClass.ClassPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];

                                for (int d = 0; d < Timetable.Days; d++)
                                {
                                    if (d < loadedJaggedPlan.Length && loadedJaggedPlan[d] != null)
                                    {
                                        for (int h = 0; h < Timetable.Hours; h++)
                                        {
                                            if (h < loadedJaggedPlan[d].Length)
                                            {
                                                // Elemente kopieren
                                                currentClass.ClassPlan[d, h] = loadedJaggedPlan[d][h];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (loadedData.AllPlans?.RoomPlans != null)
                        {
                            for (int i = 0; i < Room.AllRooms.Count; i++)
                            {
                                if (i < loadedData.AllPlans.RoomPlans.Count)
                                {
                                    Room currentRoom = Room.AllRooms[i];
                                    TimetableSlot[][] loadedJaggedPlan = loadedData.AllPlans.RoomPlans[i];

                                    currentRoom.RoomPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];

                                    for (int d = 0; d < Timetable.Days; d++)
                                    {
                                        if (d < loadedJaggedPlan.Length && loadedJaggedPlan[d] != null)
                                        {
                                            for (int h = 0; h < Timetable.Hours; h++)
                                            {
                                                if (h < loadedJaggedPlan[d].Length)
                                                {
                                                    currentRoom.RoomPlan[d, h] = loadedJaggedPlan[d][h];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (loadedData.AllPlans?.TeacherPlans != null)
                        {
                            for (int i = 0; i < Teacher.AllTeachers.Count; i++)
                            {
                                if (i < loadedData.AllPlans.TeacherPlans.Count)
                                {
                                    Teacher currentTeacher = Teacher.AllTeachers[i];
                                    TimetableSlot[][] loadedJaggedPlan = loadedData.AllPlans.TeacherPlans[i];

                                    currentTeacher.TeacherPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];

                                    for (int d = 0; d < Timetable.Days; d++)
                                    {
                                        if (d < loadedJaggedPlan.Length && loadedJaggedPlan[d] != null)
                                        {
                                            for (int h = 0; h < Timetable.Hours; h++)
                                            {
                                                if (h < loadedJaggedPlan[d].Length)
                                                {
                                                    currentTeacher.TeacherPlan[d, h] = loadedJaggedPlan[d][h];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (loadedData.AllPlans?.TeacherAvailabilities != null)
                        {
                            for (int i = 0; i < Teacher.AllTeachers.Count; i++)
                            {
                                if (i < loadedData.AllPlans.TeacherAvailabilities.Count)
                                {
                                    Teacher currentTeacher = Teacher.AllTeachers[i];
                                    bool[][] loadedJaggedAvailability = loadedData.AllPlans.TeacherAvailabilities[i];

                                    currentTeacher.Availability = new bool[Timetable.Days, Timetable.Hours];

                                    for (int d = 0; d < Timetable.Days; d++)
                                    {
                                        if (d < loadedJaggedAvailability.Length && loadedJaggedAvailability[d] != null)
                                        {
                                            for (int h = 0; h < Timetable.Hours; h++)
                                            {
                                                if (h < loadedJaggedAvailability[d].Length)
                                                {
                                                    currentTeacher.Availability[d, h] = loadedJaggedAvailability[d][h];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (Teacher.AllTeachers.Any())
                        {
                            int maxTeacherId = Teacher.AllTeachers.Max(t => t.TeacherId);
                            Teacher._iddistributor = maxTeacherId + 1;
                        }
                        else
                        {
                            Teacher._iddistributor = 1;
                        }

                        List<Student> allStudents = Schoolclass.AllClasses.SelectMany(c => c.Students).ToList();

                        if (allStudents.Any())
                        {
                            int maxStudentId = allStudents.Max(s => s.StudentId);
                            Student._iddistributor = maxStudentId + 1;
                        }
                        else
                        {
                            Student._iddistributor = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at load: {ex.Message}");
            }
        }
        public void SaveData() 
        {
            PlanContainer planContainer = new PlanContainer();

            foreach (Schoolclass sClass in Schoolclass.AllClasses)
            {
                TimetableSlot[][] jaggedArray = new TimetableSlot[Timetable.Days][];
                for (int d = 0; d < Timetable.Days; d++)
                {
                    jaggedArray[d] = new TimetableSlot[Timetable.Hours];
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        jaggedArray[d][h] = sClass.ClassPlan[d, h];
                    }
                }
                planContainer.ClassPlans.Add(jaggedArray);
            }
            foreach (Room Room in Room.AllRooms)
            {
                TimetableSlot[][] jaggedArray = new TimetableSlot[Timetable.Days][];
                for (int d = 0; d < Timetable.Days; d++)
                {
                    jaggedArray[d] = new TimetableSlot[Timetable.Hours];
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        jaggedArray[d][h] = Room.RoomPlan[d, h];
                    }
                }
                planContainer.RoomPlans.Add(jaggedArray);
            }
            foreach (Teacher Teacher in Teacher.AllTeachers)
            {
                TimetableSlot[][] jaggedArray = new TimetableSlot[Timetable.Days][];
                for (int d = 0; d < Timetable.Days; d++)
                {
                    jaggedArray[d] = new TimetableSlot[Timetable.Hours];
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        jaggedArray[d][h] = Teacher.TeacherPlan[d, h];
                    }
                }
                planContainer.TeacherPlans.Add(jaggedArray);
            }
            foreach (var teacher in Teacher.AllTeachers)
            {
                bool[][] jaggedArray = new bool[Timetable.Days][];
                for (int d = 0; d < Timetable.Days; d++)
                {
                    jaggedArray[d] = new bool[Timetable.Hours];
                    for (int h = 0; h < Timetable.Hours; h++)
                    {

                        if (teacher.Availability != null)
                        {
                            jaggedArray[d][h] = teacher.Availability[d, h];
                        }
                        else
                        {
                            jaggedArray[d][h] = false;
                        }
                    }
                }
                planContainer.TeacherAvailabilities.Add(jaggedArray);
            }
            TimetableData dataToSave = new TimetableData
            {
                AllClasses = Schoolclass.AllClasses.ToList(),
                AllTeachers = Teacher.AllTeachers.ToList(),
                AllRooms = Room.AllRooms.ToList(),
                AllSubjects = Subject.AllSubjects.ToList(),
                AllPlans = planContainer
            };

            var options = new JsonSerializerOptions { WriteIndented = true };

            try
            {
                string jsonString = JsonSerializer.Serialize(dataToSave, options);
                File.WriteAllText(FILE_PATH, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at saving: {ex.Message}");
            }
        }
    }
    public class TimetableData
    {
        public List<Schoolclass> AllClasses { get; set; }
        public List<Teacher> AllTeachers { get; set; }
        public List<Room> AllRooms { get; set; }
        public List<Subject> AllSubjects { get; set; }
        public PlanContainer AllPlans { get; set; } = new PlanContainer();
    }
    public class PlanContainer
    {
        public List<TimetableSlot[][]> ClassPlans { get; set; } = new List<TimetableSlot[][]>();
        public List<TimetableSlot[][]> TeacherPlans { get; set; } = new List<TimetableSlot[][]>();
        public List<TimetableSlot[][]> RoomPlans { get; set; } = new List<TimetableSlot[][]>();
        public List<bool[][]> TeacherAvailabilities { get; set; } = new List<bool[][]>();
    }
}