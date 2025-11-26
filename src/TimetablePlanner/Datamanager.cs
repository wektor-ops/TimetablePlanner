using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Datamanager
    {
        private const string FILE_PATH = "timetable_data.json";
        public static void LoadData() 
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

                    if (Teacher.AllTeachers.Any())
                    {
                        int maxTeacherId = Teacher.AllTeachers.Max(t => t.TeacherId);
                        Teacher._iddistributor = maxTeacherId + 1;
                    }
                    else
                    {
                        Teacher._iddistributor = 1;
                    }

                    var allStudents = Schoolclass.AllClasses.SelectMany(c => c.Students).ToList();

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error at load: {ex.Message}");
            }
        }
        public static void SaveData() 
        {
            TimetableData dataToSave = new TimetableData
            {
                AllClasses = Schoolclass.AllClasses.ToList(),
                AllTeachers = Teacher.AllTeachers.ToList(),
                AllRooms = Room.AllRooms.ToList()
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
    }
}