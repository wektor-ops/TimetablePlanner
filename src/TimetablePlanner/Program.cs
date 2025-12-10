using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//148 Funktion mache
//194
//226
//293

namespace TimetablePlanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonDatamanager datamanager = new JsonDatamanager();
            Program p = new Program();
            datamanager.LoadData();
            int newValue;

            Console.Write($"Lücken (penalty_Gap, aktuell: {Timetable.penalty_Gap}). Neuer Wert: ");
            if (int.TryParse(Console.ReadLine(), out newValue) && newValue >= 0)
            {
                Timetable.penalty_Gap = newValue;
            }

            Console.Write($"Raumwechsel (penalty_RoomChange, aktuell: {Timetable.penalty_RoomChange}). Neuer Wert: ");
            if (int.TryParse(Console.ReadLine(), out newValue) && newValue >= 0)
            {
                Timetable.penalty_RoomChange = newValue;
            }

            Console.Write($"Randstunden (penalty_EdgeHour, aktuell: {Timetable.penalty_EdgeHour}). Neuer Wert: ");
            if (int.TryParse(Console.ReadLine(), out newValue) && newValue >= 0)
            {
                Timetable.penalty_EdgeHour = newValue;
            }

            Console.Write($"Raumnutzung (penalty_RoomsUse, aktuell: {Timetable.penalty_RoomsUse}). Neuer Wert: ");
            if (int.TryParse(Console.ReadLine(), out newValue) && newValue >= 0)
            {
                Timetable.penalty_RoomsUse = newValue;
            }
            p.FirstQ();
            datamanager.SaveData();
        }
        public void FirstQ()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(" [1] Student\n [2] Teacher\n [3] Schoolclass\n [4] Subject\n [5] Room\n [6] Timetable\n [7] Export\n [0] End Program");
                string Auswahl = Console.ReadLine();

                switch (Auswahl)
                {
                    case "1":

                        MStudent();
                        break;
                    case "2":
                        MTeacher();


                        break;
                    case "3":
                        MSchoolclass();
                        break;
                    case "4":
                        MSubject();
                        break;
                    case "5": 
                        Mroom();
                        break;
                    case "6":
                        MTimetable();
                        break;
                    case "7":
                        MExport();
                        break;

                    default: return;
                }
            }
            while (true);
        }

        public void MExport() 
        {
            Console.Clear();
            Console.WriteLine("Export Timetable of\n [1] Student\n [2] Teacher\n [3] Schoolclass\n [4] Room\n [0] Back");
            string Auswahl = Console.ReadLine();
            switch (Auswahl) 
            {
                case "1":
                    MChooseStudent();
                    break;
                case "2":
                    MChooseTeacher();
                    break;
                case "3":
                    MChooseSchoolclass();
                    break;
                case "4":
                    MChooseRoom();
                    break;
                case "0":
                    return;
                default: return;

            }
        }

        public void MChooseStudent() 
        {
            Console.Clear();
        

           
                Student foundStudent;
                do
                {
                Console.WriteLine("All Students: ");
                foreach (Schoolclass c in Schoolclass.AllClasses)
                    {
                   
                    foreach (Student s in c.Students)
                    
                            Console.Write( s.Firstname + " " + s.Lastname + "  ");
                    }

                    Console.WriteLine("\n\nPlease enter firstname of Student");

                    string firstnameofstudent = Console.ReadLine();
                    Console.WriteLine("Please enter Surname of Student");
                    string surnameofstudent = Console.ReadLine();
                    Console.Clear();
                    string AntwortStudentcorr;
                    foreach (Schoolclass schoolClass in Schoolclass.AllClasses)
                    {
                        foundStudent = schoolClass.Students.Find(s => s.Firstname == firstnameofstudent && s.Lastname == surnameofstudent);
                        if (foundStudent != null && schoolClass.ClassPlan != null)
                        {
                        Console.WriteLine("Timetable of: " + firstnameofstudent + " " + surnameofstudent);
                            Timetable.OutputTimetable(schoolClass);
                            Console.WriteLine("[1] Export Timetable");
                            Console.WriteLine("[0] Back to Menu");
                            AntwortStudentcorr = Console.ReadLine();
                            if (AntwortStudentcorr == "0")
                                return;
                        if (AntwortStudentcorr == "1")
                            return;//Export Funktion anstelle von return
                            
                        }




                    }
                    Console.WriteLine("[0] Back to Menu");
                    AntwortStudentcorr = Console.ReadLine();
                    if (AntwortStudentcorr == "0")
                        return;
                } while (true);
        }


        public void MChooseTeacher()
        {

             Console.Clear ();

            Console.WriteLine("All Teachers: ");
                foreach (Teacher t in Teacher.AllTeachers)
                    Console.Write(t.Firstname + " " + t.LastName + "  ");
                Console.WriteLine("\n\nPlease enter firstname of Teacher");

                string firstnameofteacher = Console.ReadLine();
                Console.WriteLine("Please enter Surname of Teacher");
                string surnameofteacher = Console.ReadLine();

                string AntwortTeachercorr;
                if (Teacher.AllTeachers.Find(t => t.Firstname == firstnameofteacher && t.LastName == surnameofteacher) != null && Teacher.AllTeachers.Find(t => t.Firstname == firstnameofteacher && t.LastName == surnameofteacher).TeacherPlan != null)
                {
                    Console.Clear();
                Console.WriteLine("Timetable of Teacher: ");
                    Console.WriteLine( firstnameofteacher + " " + surnameofteacher );
                    Timetable.OutputTimetable(Teacher.AllTeachers.Find(t => t.Firstname == firstnameofteacher && t.LastName == surnameofteacher));
                    Console.WriteLine("[1] Export Timetable");
                    Console.WriteLine("[0] Back to Menu");

                    AntwortTeachercorr = Console.ReadLine();
                    if (AntwortTeachercorr == "0")
                        return;
                    if(AntwortTeachercorr == "1")
                    return;//Hier auch die Funktion
                }
                Console.WriteLine("[0] Back to Menu");
                AntwortTeachercorr = Console.ReadLine();
                if (AntwortTeachercorr == "0")
                    return;
            
        }
        public void MChooseSchoolclass()
        {
            Console.Clear();
                foreach (Schoolclass c in Schoolclass.AllClasses)
                        Console.Write(c.Abbreviation + " ");
                    Console.WriteLine("\n\nPlease enter Class abbrevation");

                    string Classabrv = Console.ReadLine();

                    string AntworClasscorr;
                    foreach (Schoolclass schoolClass in Schoolclass.AllClasses)
                    {
                        Schoolclass foundclass = Schoolclass.AllClasses.Find(c => c.Abbreviation == Classabrv);
                        if (foundclass != null && foundclass.ClassPlan != null)
                        {
                            Console.Clear();
                            Console.WriteLine("Timetable of Class: ");
                            Console.WriteLine(Classabrv);
                            Timetable.OutputTimetable(foundclass);
                            Console.WriteLine("[1] Export Timetable");
                            Console.WriteLine("[0] Back to Menu");
                            AntworClasscorr = Console.ReadLine();
                            if (AntworClasscorr == "0")
                                return;
                    if (AntworClasscorr == "1")
                        return; // Hier auch die Funktion
                        }



                    }
                    Console.WriteLine("[0] Back to Menu");
                    AntworClasscorr = Console.ReadLine();
                    if (AntworClasscorr == "0")
                        return;
                


            
        }
        public void MChooseRoom()
        {

            Console.Clear();
            Console.WriteLine("All rooms: ");
            foreach (Room r in Room.AllRooms)              
                    Console.Write( r.Abbreviation + " ");
                Console.WriteLine("\n\nPlease enter Abrrevation of Room(4 Characters)");
                string SFRA = Console.ReadLine();
                if (SFRA.Length == 4)
                {
                    if (Room.AllRooms.Find(r => r.Abbreviation == SFRA) != null && Room.AllRooms.Find(r => r.Abbreviation == SFRA).RoomPlan != null)
                    {
                    Console.Clear();
                    Console.WriteLine("Timetable of Room: ");
                    Console.WriteLine( SFRA);
                        Timetable.OutputTimetable(Room.AllRooms.Find(r => r.Abbreviation == SFRA));
                        Console.WriteLine("[1] Export Timetable");
                        Console.WriteLine("[0] Back to Menu");
                        string AntwortRoomcorr = Console.ReadLine();
                        if (AntwortRoomcorr == "0")
                            return;
                        if (AntwortRoomcorr == "1")
                        return; // Hier auch die Funktion
                    }


                }



            
        }
        




        public void MStudent()
        {
            do
            {
                Console.WriteLine("[1] Show Students,\n[2] Add Students\n[0] Back to menu");
                string AuswahlStudent = Console.ReadLine();

                switch (AuswahlStudent)
                {
                    case "1":


                        StudentShow();
                        break;
                    case "2":

                        
                        Studentnew();
                        break;
                    case "0":
                        return;


                }
            }
            while (true);
        }
        public void Studentnew()
        {


            Console.WriteLine("Please Enter fistname of student");
            string studentfirstname = Console.ReadLine();
            Console.WriteLine("Please Enter lastname of student");
            string studentlastname = Console.ReadLine();

            new Student(studentfirstname, studentlastname);
            JsonDatamanager datamanager = new JsonDatamanager();
            datamanager.SaveData();

        }

        public void StudentShow()
        {
            do
            {
                foreach (Schoolclass sc in Schoolclass.AllClasses)
                    foreach (Student s in sc.Students)
                        Console.WriteLine(s.Firstname + " " + s.Lastname + " ");

                Console.WriteLine("[0] Back");
                string AntwortStudentShow = Console.ReadLine();
                if (AntwortStudentShow == "0")
                    return;

            } while (true);
        }
        public void MTeacher()
        {
            do
            {
                Console.WriteLine("[1] Show Teachers,\n[2] Add Teachers\n[0] Back to menu");
                string AuswahlTeacher = Console.ReadLine();

                switch (AuswahlTeacher)
                {
                    case "1":

                        Teachershow();
                        
                        break;
                    case "2":

                        Teachernew();
                        break;
                    case "0":
                        return;


                }
            } while (true);
        }
        public void Teachershow()
        {
            do
            {
                foreach (Teacher t in Teacher.AllTeachers)
                    Console.WriteLine(t.Firstname + " " + t.LastName);
                Console.WriteLine("[0] Back");
                string AntwortTeacherShow = Console.ReadLine();
                if (AntwortTeacherShow == "0")
                    return;
            } while (true);
        }
        public void Teachernew()
        {

            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortTeachernew = Console.ReadLine();
            if (AntwortTeachernew == "0")
                return;
            else
            {

                Console.WriteLine("Please Enter fistname of teacher");
                string teacherfirstname = Console.ReadLine();
                Console.WriteLine("Please Enter lastname of teacher");
                string teacherlastname = Console.ReadLine();

                bool[,] Availability = new bool[Timetable.Days, Timetable.Hours];
                Console.WriteLine("[1]Fulltime or [2]Parttime");
                string Timeatwork = Console.ReadLine();
                for (int d = 0; d < Timetable.Days; d++)
                {
                    for (int h = 0; h < Timetable.Hours; h++)
                    {
                        Availability[d, h] = true;
                    }
                }

                if (Timeatwork == "2")
                {
                    string Daysoffwork;

                    do
                    {
                        Console.WriteLine("Which days are you gone\n\n[Mo] Monday\n[Tu] Tuesday\n[We] Wednesday\n[Th] Thursday\n[Fr] Friday\n[X] Exit");
                        Daysoffwork = Console.ReadLine();
                        switch (Daysoffwork)
                        {
                            case "Mo":
                                Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                                string MOE = Console.ReadLine();
                                if (MOE == "M")
                                {
                                    Availability[0, 0] = false;
                                    Availability[0, 1] = false;
                                    Availability[0, 2] = false;
                                    Availability[0, 3] = false;
                                    Availability[0, 4] = false;
                                }
                                if (MOE == "E")
                                {
                                    Availability[0, 5] = false;
                                    Availability[0, 6] = false;
                                    Availability[0, 7] = false;
                                    Availability[0, 8] = false;
                                    Availability[0, 9] = false;
                                    Availability[0, 10] = false;
                                }
                                if (MOE == "W")
                                {
                                    Availability[0, 0] = false;
                                    Availability[0, 1] = false;
                                    Availability[0, 2] = false;
                                    Availability[0, 3] = false;
                                    Availability[0, 4] = false;
                                    Availability[0, 5] = false;
                                    Availability[0, 6] = false;
                                    Availability[0, 7] = false;
                                    Availability[0, 8] = false;
                                    Availability[0, 9] = false;
                                    Availability[0, 10] = false;
                                }
                                break;

                            case "Tu":
                                Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                                string MOET = Console.ReadLine();
                                if (MOET == "M")
                                {
                                    Availability[1, 0] = false;
                                    Availability[1, 1] = false;
                                    Availability[1, 2] = false;
                                    Availability[1, 3] = false;
                                    Availability[1, 4] = false;
                                }
                                if (MOET == "E")
                                {
                                    Availability[1, 5] = false;
                                    Availability[1, 6] = false;
                                    Availability[1, 7] = false;
                                    Availability[1, 8] = false;
                                    Availability[1, 9] = false;
                                    Availability[1, 10] = false;
                                }
                                if (MOET == "W")
                                {
                                    Availability[1, 0] = false;
                                    Availability[1, 1] = false;
                                    Availability[1, 2] = false;
                                    Availability[1, 3] = false;
                                    Availability[1, 4] = false;
                                    Availability[1, 5] = false;
                                    Availability[1, 6] = false;
                                    Availability[1, 7] = false;
                                    Availability[1, 8] = false;
                                    Availability[1, 9] = false;
                                    Availability[1, 10] = false;
                                }
                                break;
                            case "We":
                                Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                                string MOEW = Console.ReadLine();
                                if (MOEW == "M")
                                {
                                    Availability[2, 0] = false;
                                    Availability[2, 1] = false;
                                    Availability[2, 2] = false;
                                    Availability[2, 3] = false;
                                    Availability[2, 4] = false;
                                }
                                if (MOEW == "E")
                                {
                                    Availability[2, 5] = false;
                                    Availability[2, 6] = false;
                                    Availability[2, 7] = false;
                                    Availability[2, 8] = false;
                                    Availability[2, 9] = false;
                                    Availability[2, 10] = false;
                                }
                                if (MOEW == "W")
                                {
                                    Availability[2, 0] = false;
                                    Availability[2, 1] = false;
                                    Availability[2, 2] = false;
                                    Availability[2, 3] = false;
                                    Availability[2, 4] = false;
                                    Availability[2, 5] = false;
                                    Availability[2, 6] = false;
                                    Availability[2, 7] = false;
                                    Availability[2, 8] = false;
                                    Availability[2, 9] = false;
                                    Availability[2, 10] = false;
                                }
                                break;
                            case "Th":
                                Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                                string MOETH = Console.ReadLine();
                                if (MOETH == "M")
                                {
                                    Availability[3, 0] = false;
                                    Availability[3, 1] = false;
                                    Availability[3, 2] = false;
                                    Availability[3, 3] = false;
                                    Availability[3, 4] = false;
                                }
                                if (MOETH == "E")
                                {
                                    Availability[3, 5] = false;
                                    Availability[3, 6] = false;
                                    Availability[3, 7] = false;
                                    Availability[3, 8] = false;
                                    Availability[3, 9] = false;
                                    Availability[3, 10] = false;
                                }
                                if (MOETH == "W")
                                {
                                    Availability[3, 0] = false;
                                    Availability[3, 1] = false;
                                    Availability[3, 2] = false;
                                    Availability[3, 3] = false;
                                    Availability[3, 4] = false;
                                    Availability[3, 5] = false;
                                    Availability[3, 6] = false;
                                    Availability[3, 7] = false;
                                    Availability[3, 8] = false;
                                    Availability[3, 9] = false;
                                    Availability[3, 10] = false;
                                }
                                break;
                            case "Fr":
                                Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                                string MOEF = Console.ReadLine();
                                if (MOEF == "M")
                                {
                                    Availability[4, 0] = false;
                                    Availability[4, 1] = false;
                                    Availability[4, 2] = false;
                                    Availability[4, 3] = false;
                                    Availability[4, 4] = false;
                                }
                                if (MOEF == "E")
                                {
                                    Availability[4, 5] = false;
                                    Availability[4, 6] = false;
                                    Availability[4, 7] = false;
                                    Availability[4, 8] = false;
                                    Availability[4, 9] = false;
                                    Availability[4, 10] = false;
                                }
                                if (MOEF == "W")
                                {
                                    Availability[4, 0] = false;
                                    Availability[4, 1] = false;
                                    Availability[4, 2] = false;
                                    Availability[4, 3] = false;
                                    Availability[4, 4] = false;
                                    Availability[4, 5] = false;
                                    Availability[4, 6] = false;
                                    Availability[4, 7] = false;
                                    Availability[4, 8] = false;
                                    Availability[4, 9] = false;
                                    Availability[4, 10] = false;
                                }
                                break;
                        }
                        

                    }
                    while (Daysoffwork != "X");
                }
                new Teacher(teacherfirstname, teacherlastname, Availability);

                if (Teacher.AllTeachers.Count >= Schoolclass.AllClasses.Count && Room.AllRooms.Count >= Schoolclass.AllClasses.Count)
                {
                    Timetable.Build();
                }
                else Console.WriteLine("Not enough teachers/rooms available.");
                JsonDatamanager datamanager = new JsonDatamanager();
                datamanager.SaveData();
                return;
            }
        }
        public void MSchoolclass()
        {
            do
            {
                Console.WriteLine("[1] Show all classes, [2] Add Subject to Curriculum, [0] Back");
                string AuswahlSchoolclass = Console.ReadLine();
                switch (AuswahlSchoolclass)
                {
                    case "1":
                        foreach (Schoolclass sc in Schoolclass.AllClasses)
                            Console.WriteLine(sc.Abbreviation + " ");
                        break;

                    case "2":
                        MStoC();

                        break;
                    case "0":
                        return;

                }
            } while (true);
        }
        public void MStoC()
        {
            do
            {
                Console.WriteLine("\n[1] Do you want to add a Subject to a already existing class?, [0] Back ");
                string AntwortC2OfMScm = Console.ReadLine();
                if (AntwortC2OfMScm == "0")
                {
                    return;
                }
                else
                {

                    Console.WriteLine("\n\nEnter Abrrivation of Class where you want to change Curriculum");
                    string ClassofCurriculum = Console.ReadLine();
                    if (Schoolclass.AllClasses.Find(sc => sc.Abbreviation == ClassofCurriculum) != null)
                    {
                        foreach (Subject sj in Subject.AllSubjects)
                            Console.Write(sj.Abbreviation + " ");
                        Console.WriteLine("\nEnter Abrrivation of chosen Subject");
                        string EAOCS = Console.ReadLine();

                        if (Subject.AllSubjects.Find(s => s.Abbreviation == EAOCS) != null)
                        {
                            Console.WriteLine("How many lessons per week in this Subject?");
                            int LessonsofSubjectperweek = int.Parse(Console.ReadLine());
                            for (int i = 0; i < LessonsofSubjectperweek; i++)
                            {
                                Schoolclass.AllClasses.Find(sc => sc.Abbreviation == ClassofCurriculum).Curriculum.Add(Subject.AllSubjects.Find(s => s.Abbreviation == EAOCS));
                            }
                            if (Teacher.AllTeachers.Count >= Schoolclass.AllClasses.Count && Room.AllRooms.Count >= Schoolclass.AllClasses.Count)
                                Timetable.Build();
                            else Console.WriteLine("Not enough teachers/rooms available.");
                            JsonDatamanager datamanager = new JsonDatamanager();
                            datamanager.SaveData();
                        }
                        else
                        {
                            Console.WriteLine("Subject not found!");
                            MStoC();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Class not found!");
                        MStoC();
                    }


                }

            } while (true);
        }
        public void MSubject()
        {

            Console.WriteLine("[1] Show all subjects, [2] Create new subject, [0] Back");
            string AuswahlSubject = Console.ReadLine();
            switch (AuswahlSubject)
            {
                case "1":

                    foreach (Subject sj in Subject.AllSubjects)
                        Console.Write(sj.Abbreviation + " ");
                    Console.ReadKey();
                    break;

                case "2":
                    foreach (Subject sj in Subject.AllSubjects)
                        Console.Write(sj.Abbreviation + " ");
                    Console.WriteLine("\nAbbrevation of subject?");
                    string subjectabrrvation = Console.ReadLine();


                    Subject.AllSubjects.Add(new Subject(subjectabrrvation));

                    break;


                case "0":
                    return;


            }



        }
        public void Mroom()
        {
            Console.WriteLine("[1] Show all rooms, [2] Create new room, [0] Back");
            string AuswahlSubject = Console.ReadLine();
            switch (AuswahlSubject)
            {
                case "1":

                    foreach (Room r in Room.AllRooms)
                        Console.Write(r.Abbreviation + " ");
                    Console.WriteLine("\n[0] Back");
                    string roomc1 = Console.ReadLine();
                    if (roomc1 == "0")
                        return;



                    break;

                case "2":
                    Console.WriteLine("Name of room?");
                    string roomname = Console.ReadLine();

                    while (roomname.Length != 4)
                    {
                        Console.WriteLine("The name has to be 4 characters long: ");
                        roomname = Console.ReadLine();
                    }


                    Room.AllRooms.Add(new Room(roomname));
                    if (Teacher.AllTeachers.Count >= Schoolclass.AllClasses.Count && Room.AllRooms.Count >= Schoolclass.AllClasses.Count)
                        Timetable.Build();
                    else Console.WriteLine("Not enough teachers/rooms available.");
                    JsonDatamanager datamanager = new JsonDatamanager();
                    datamanager.SaveData();
                    break;
                case "0":
                    return;
            }
        }




        public void MTimetable()
        {
            Console.WriteLine("[1] Show Timetable, [0] Back");
            string AntwortTimetable = Console.ReadLine();
            switch (AntwortTimetable)
            {
                case "1":
                    Console.WriteLine("[1] Class, [2] Student, [3] Teacher, [4] Room, [0] Back");
                    string AntwortTimetablec1 = Console.ReadLine();
                    switch (AntwortTimetablec1)
                    {

                        case "1":
                            ShowCofTimetable();
                            break;
                        case "2":
                            ShowSofTimetable();
                            break;
                        case "3":
                            ShowTofTimetable();
                            break;
                        case "4":
                            ShowRofTimetable();
                            break;
                        case "0":
                            return;

                    }
                    break;


                case "0":
                    return;

            }
        }
        public void ShowSofTimetable()
        {

            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortCorB = Console.ReadLine();
            if (AntwortCorB == "0")
                return;
            else if (AntwortCorB == "1")
            {
                Student foundStudent;
                do
                {
                    foreach (Schoolclass c in Schoolclass.AllClasses)
                    {
                        foreach (Student s in c.Students)
                            Console.Write(s.Firstname + " " + s.Lastname + "  ");
                    }
                        
                    Console.WriteLine("\n\nPlease enter firstname of Student");

                    string firstnameofstudent = Console.ReadLine();
                    Console.WriteLine("Please enter Surname of Student");
                    string surnameofstudent = Console.ReadLine();

                    string AntwortStudentcorr;
                    foreach (Schoolclass schoolClass in Schoolclass.AllClasses)
                    {
                        foundStudent = schoolClass.Students.Find(s => s.Firstname == firstnameofstudent && s.Lastname == surnameofstudent);
                        if (foundStudent != null && schoolClass.ClassPlan != null)
                        {
                            Timetable.OutputTimetable(schoolClass);
                            Console.WriteLine("[0] Back to Menu");
                            AntwortStudentcorr = Console.ReadLine();
                            if (AntwortStudentcorr == "0")
                                return;
                        }




                    }
                    Console.WriteLine("[0] Back to Menu");
                    AntwortStudentcorr = Console.ReadLine();
                    if (AntwortStudentcorr == "0")
                        return;
                } while (true);
            }

        }
        public void ShowCofTimetable()
        {
            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortCorB = Console.ReadLine();
            if (AntwortCorB == "0")
                return;
            else if (AntwortCorB == "1")
            {
                do
                {
                    foreach (Schoolclass c in Schoolclass.AllClasses)
                        Console.Write(c.Abbreviation + " ");
                    Console.WriteLine("\n\nPlease enter Class abbrevation");

                    string Classabrv = Console.ReadLine();

                    string AntworClasscorr;
                    foreach (Schoolclass schoolClass in Schoolclass.AllClasses)
                    {
                        Schoolclass foundclass = Schoolclass.AllClasses.Find(c => c.Abbreviation == Classabrv);
                        if (foundclass != null && foundclass.ClassPlan != null)
                        {
                            Timetable.OutputTimetable(foundclass);
                            Console.WriteLine("[0] Back to Menu");
                            AntworClasscorr = Console.ReadLine();
                            if (AntworClasscorr == "0")
                                return;
                        }



                    }
                    Console.WriteLine("[0] Back to Menu");
                    AntworClasscorr = Console.ReadLine();
                    if (AntworClasscorr == "0")
                        return;
                } while (true);


            }
        }
        public void ShowTofTimetable()
        {

            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortCorB = Console.ReadLine();
            if (AntwortCorB == "0")
                return;
            else if (AntwortCorB == "1")
            {
                foreach (Teacher t in Teacher.AllTeachers)
                    Console.Write(t.Firstname + " " + t.LastName + "  ");
                Console.WriteLine("\n\nPlease enter firstname of Teacher");

                string firstnameofteacher = Console.ReadLine();
                Console.WriteLine("Please enter Surname of Teacher");
                string surnameofteacher = Console.ReadLine();

                string AntwortTeachercorr;
                if (Teacher.AllTeachers.Find(t => t.Firstname == firstnameofteacher && t.LastName == surnameofteacher) != null && Teacher.AllTeachers.Find(t => t.Firstname == firstnameofteacher && t.LastName == surnameofteacher).TeacherPlan != null)
                {
                    Timetable.OutputTimetable(Teacher.AllTeachers.Find(t => t.Firstname == firstnameofteacher && t.LastName == surnameofteacher));
                    Console.WriteLine("[0] Back to Menu");
                    AntwortTeachercorr = Console.ReadLine();
                    if (AntwortTeachercorr == "0")
                        return;
                }
                Console.WriteLine("[0] Back to Menu");
                AntwortTeachercorr = Console.ReadLine();
                if (AntwortTeachercorr == "0")
                    return;
            }
        }
        public void ShowRofTimetable()
        {
            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortCorB = Console.ReadLine();
            if (AntwortCorB == "0")
                return;
            else if (AntwortCorB == "1")
            {
                foreach (Room r in Room.AllRooms)
                    Console.Write(r.Abbreviation + " ");
                Console.WriteLine("\n\nPlease enter Abrrevation of Room(4 Characters)");
                string SFRA = Console.ReadLine();
                if (SFRA.Length == 4)
                {
                    if (Room.AllRooms.Find(r => r.Abbreviation == SFRA) != null && Room.AllRooms.Find(r => r.Abbreviation == SFRA).RoomPlan != null)
                    {
                        Timetable.OutputTimetable(Room.AllRooms.Find(r => r.Abbreviation == SFRA));
                        Console.WriteLine("[0] Back to Menu");
                        string AntwortRoomcorr = Console.ReadLine();
                        if (AntwortRoomcorr == "0")
                            return;
                    }


                }



            }
        }


    }
}
