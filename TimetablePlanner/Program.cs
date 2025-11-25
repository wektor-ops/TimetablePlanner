using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimetablePlanner;

namespace TimetablePlanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[1] Student\n[2] Teacher\n[3] Schoolclass\n[4] Subject\n[5] Room\n [5] Plan\n[6] Safe Data\n [7] Timetable");
            int Auswahl = Console.ReadLine();

            switch (Auswahl)
            {
                case 1:

                    MStudent();
                break;
                case 2:
                    MTeacher();


                 break;
                case 3:
                    MSchoolclass();
                break;
                case 4:
                    MSubject();
                        break;
                case 5:
                    Mroom();
                        break;
                case 6:
                    MPlan();
                        break;
                case 7:
                    MData();
                        break;
                case 8:
                    MTimetable();
                        break;
            }




        }
        public void MStudent()
        {
            Console.WriteLine("[1] Show Students,\n[2] Add Students\n[0] Back to menu");
                int AuswahlStudent = Console.ReadKey();
            
            switch (AuswahlStudent)
            {
                case 1:
                    
                       Studentnew()
                break;
                case 2: 
                    
                        StudentShow()
                break;
                case 0:
                    Main()
                        break;

            }
        }
        public void Studentnew()
        {
            Console.WriteLine("Please Enter fistname of student");
            string studentfirstname = Console.ReadLine();
            Console.WriteLine("Please Enter lastname of student");
            string studentlastname = Console.ReadLine();
            new Student(studentfirstname, studentlastname);
            Student.Allstudents.Add(Student)

        }
        
        public void StudentShow() 
        {
            
            foreach (Student s in Student.Allstudents)
                Console.WriteLine(s.Firstname + " " + s.Lastname + " - " + s.Class.Abbreviation);
            Console.WriteLine("[0] Back");
            int AntwortStudentShow = Console.ReadLine();
            if(AntwortStudentShow == 0)
                MStudent();

        }
        public void MTeacher() 
        {
            Console.WriteLine("[1] Show Teachers,\n[2] Add Teachers\n[0] Back to menu");
            int AuswahlTeacher = Console.ReadKey();

            switch (AuswahlTeacher)
            {
                case 1:

                    Teachernew()
                break;
                case 2:

                    Teachershow()
                break;
                case 0:
                    Main();
                    break;

            }
        }
        public void Teachershow() 
        {
            foreach (Teacher t in Teacher.AllTeachers)
                Console.WriteLine(t.Firstname + " " + t.Lastname);
            Console.WriteLine("[0] Back");
            int AntwortTeacherShow = Console.ReadLine();
            if(AntwortTeacherShow == 0)
                MTeacher();
        }
        public void Teachernew() 
        {
            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortTeachernew = Console.ReadLine();
            if (AntwortTeachernew == 0)
                MTeacher();
            else {

                Console.WriteLine("Please Enter fistname of teacher");
                string teacherfirstname = Console.ReadLine();
                Console.WriteLine("Please Enter lastname of teacher");
                string teacherlastname = Console.ReadLine();
                new Teacher(teacherfirstname, teacherlastname)
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

                if (Timeatwork == 2)
                {
                    string Daysoffwork;
               
                do 
                {
                    Console.WriteLine("Which days are you gone\n\n[Mo] Monday\n[Tu] Tuesday\n[We] Wednesday\n[Th] Thursday\n[Fr] Friday\n[X] Exit");
                     Daysoffwork = Console.ReadLine();
                    switch (Daysoffwork) 
                    {
                        case "Mo": Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day"); 
                            string MOE = Console.ReadLine();
                            if (MOE == "M")
                                Availability[0, 0] = false;
                                Availability[0, 1] = false;
                                Availability[0, 2] = false;
                                Availability[0, 3] = false;
                                Availability[0, 4] = false;
                            if(MOE == "E")
                                Availability[0, 5] = false;
                                Availability[0, 6] = false;
                                Availability[0, 7] = false;
                                Availability[0, 8] = false;
                                Availability[0, 9] = false;
                                Availability[0, 10] = false;
                            if(MOE == "W")
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
                        break;
                        
                        case "Tu":
                            Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                            string MOE = Console.ReadLine();
                            if (MOE == "M")
                                Availability[1, 0] = false;
                                Availability[1, 1] = false;
                                Availability[1, 2] = false;
                                Availability[1, 3] = false;
                                Availability[1, 4] = false;
                            if (MOE == "E")
                                Availability[1, 5] = false;
                                Availability[1, 6] = false;
                                Availability[1, 7] = false;
                                Availability[1, 8] = false;
                                Availability[1, 9] = false;
                                Availability[1, 10] = false;
                            if (MOE == W"")
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
                        break;
                        case "We":
                            Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                            string MOE = Console.ReadLine();
                            if (MOE == "M")
                                Availability[2, 0] = false;
                            Availability[2, 1] = false;
                            Availability[2, 2] = false;
                            Availability[2, 3] = false;
                            Availability[2, 4] = false;
                            if (MOE == "E")
                                Availability[2, 5] = false;
                            Availability[2, 6] = false;
                            Availability[2, 7] = false;
                            Availability[2, 8] = false;
                            Availability[2, 9] = false;
                            Availability[2, 10] = false;
                            if (MOE == "W")
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
                            break;
                        case "Th":
                            Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                            string MOE = Console.ReadLine();
                            if (MOE == "M")
                                Availability[3, 0] = false;
                            Availability[3, 1] = false;
                            Availability[3, 2] = false;
                            Availability[3, 3] = false;
                            Availability[3, 4] = false;
                            if (MOE == "E")
                                Availability[3, 5] = false;
                            Availability[3, 6] = false;
                            Availability[3, 7] = false;
                            Availability[3, 8] = false;
                            Availability[3, 9] = false;
                            Availability[3, 10] = false;
                            if (MOE == "W")
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
                            break;
                        case "Fr":
                            Console.WriteLine("[M]Morning, [E]Evening or [W] Whole Day");
                            string MOE = Console.ReadLine();
                            if (MOE == "M")
                                Availability[4, 0] = false;
                            Availability[4, 1] = false;
                            Availability[4, 2] = false;
                            Availability[4, 3] = false;
                            Availability[4, 4] = false;
                            if (MOE == "E")
                                Availability[4, 5] = false;
                            Availability[4, 6] = false;
                            Availability[4, 7] = false;
                            Availability[4, 8] = false;
                            Availability[4, 9] = false;
                            Availability[4, 10] = false;
                            if (MOE == "W")
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
                            break;
                    }
                        Main();

                    }
while (Daysoffwork != "X")}
                Main();

            }
    public void MSchoolclass() 
{
    Console.WriteLine("[1] Show all classes, [2] Change class, [0] Back");
    string AuswahlSchoolclass =  Console.ReadLine();
    switch (AuswahlSchoolclass)
    {
        case 1:
            foreach (Schoolclass sc in Schoolclass.AllClasses)
                Console.WriteLine(sc.Abbreviation + " ");
            break;

        case 2:
            foreach (Schoolclass sc in Schoolclass.AllClasses)
                Console.WriteLine(sc.Curriculum + " "); 
            //wiktor frage
            break;
        case 0:
                    Main();
            break;
    }
}
public void MSubject() 
{
    Console.WriteLine("[1] Show all subjects, [2] Create new subject, [0] Back");
     string AuswahlSubject = Console.ReadLine();
    switch (AuswahlSubject)
    {
        case 1:
            //Von Liste Anzeigen
            break;
        
        case 2:
            Console.WriteLine("Name of Subject?");
            string subjectname = Console.ReadLine();
            Console.WriteLine("Abbrevation of subject?")
            string subjectabrrvation = Console.ReadLine();
            // Hier noch zur Liste hinzufügen
            break;


        case 0:
                    MSchoolclass();
                
            break;
    }
       


                   
}
public void Mroom()
{
    Console.WriteLine("[1] Show all rooms, [2] Create new room, [0] Back");
    string AuswahlSubject = Console.ReadLine();
    switch (AuswahlSubject)
    {
        case 1:
            //Von Liste Anzeigen
            foreach (Room r in Room.AllRooms)
                Console.WriteLine(r.Abbreviation + " ");
            Console.WriteLine("\n[0] Back");
            int roomc1 = Console.ReadLine();
            if (roomc1) = 0
                    Mroom()
            
            break;

        case 2:
            Console.WriteLine("Name of room?");
            string roomname = Console.ReadLine();
           Room.AllRooms.Add(roomname)
            Mroom()
            
            break;


        case 0:
                    Main();

            break;
    }




}
public void MPlan()
{
    //Ka was da ihne muss bruche andei Sache
}
public void MData()
{
            //Ka was da ihne muss bruche andei Sache
}
        public void MTimetable() 
{
    Console.WriteLine("[1] Show Timetable, [2] Create Timetable, [0] Back");
    string AntwortTimetable = Console.ReadLine();
    switch(AntwortTimetable) 
    {
        case 1:
            Console.WriteLine("[1] Class, [2] Student, [3] Teacher, [0] Back");
            string AntwortTimetablec1 = Console.ReadLine();
            switch (AntwortTimetablec1)
            {
                
                case 1: ShowCofTimetable()
                        break;
                case 2: ShowSofTimetable()
                        break;
                case 3: ShowTofTimetable()
                        break;
                case 0: MTimetable()
                        break;
            }
            break;
            case 2: CreateTimetable()
                break;
            case 3: MTimetable()
                break;
                case 0:
                    Main();
    }
}
public void ShowSofTimetable() 
{
    Console.WriteLine("[1]Continue, [0] Back");
    string AntwortCorB = Console.ReadLine();
    if(AntwortCorB == 0)
        MTimetable()
    else if (AntwortCorB == 1) { 
        Console.WriteLine("Please enter firstname of Student");

    string firstnameofstudent = Console.ReadLine();
    Console.WriteLine("Please enter Surname of Student");
    string surnameofstudent = Console.ReadLine();
        for (int i = 0; i < Student.Allstudents.Count; i++)
        {
            if (Student[i].Firstname == firstnameofstudent &&
                Student[i].Lastname == surnameofstudent)
            {
                        //Stundenplan für Schüler i angeben
                        Console.WriteLine("[0] Back to Menu");
                        int AntwortStudentcorr = Console.ReadLine();
                        if (AntwortStudentcorr == 0)
                            Main();
            }
            else { Console.WriteLine("Student not found. [0] Back");
                int AntwortStudnetfound = Console.ReadLine();
                if (AntwortStudnetfound == 0)
                {
                            MTimetable();
                }
            }

        }


    
}
public void ShowCofTimetable()
{
            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortCorB = Console.ReadLine();
            if (AntwortCorB == 0)
                MTimetable()
            else if (AntwortCorB == 1)
            {
                Console.WriteLine("Please enter Class abbrevation");

                string Classabrv = Console.ReadLine();
            
                for (int i = 0; i < Schoolclass.AllClasses.Count; i++)
                {
                    //Schauen wie es Heisst
                    if (Schoolclass[i].Abrr == Classabrv )
                        
                    {
                        //Stundenplan für Classe i anzeigen
                        Console.WriteLine("[0] Back to Menu");
                        int AntwortStudentcorr = Console.ReadLine();
                        if (AntwortStudentcorr == 0)
                            Main();
                    }
                    else
                    {
                        Console.WriteLine("Class not found. [0] Back");
                        int AntwortStudnetfound = Console.ReadLine();
                        if (AntwortStudnetfound == 0)
                        {
                            MTimetable();
                        }
                    }

                }



            }
public void ShowTofTimetable()
{

            Console.WriteLine("[1]Continue, [0] Back");
            string AntwortCorB = Console.ReadLine();
            if (AntwortCorB == 0)
                MTimetable()
            else if (AntwortCorB == 1)
            {
                Console.WriteLine("Please enter firstname of Teacher");

                string firstnameofteacher = Console.ReadLine();
                Console.WriteLine("Please enter Surname of Teacher");
                string surnameofteacher = Console.ReadLine();
                for (int i = 0; i < Teacher.AllTeachers.Count; i++)
                {
                    if (Teacher[i].Firstname == firstnameofteacher &&
                        Teacher[i].Lastname == surnameofteacher)
                    {
                        //Stundenplan für Teacher i angeben
                        Console.WriteLine("[0] Back to Menu");
                        int AntwortTeachercorr = Console.ReadLine();
                        if (AntwortTeachercorr == 0)
                            Main();
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found. [0] Back");
                        int AntwortTeacherfound = Console.ReadLine();
                        if (AntwortTeacherfound == 0)
                        {
                            MTimetable();
                        }
                    }

                }
            }
public void CreateTimetable()
{
    //Createn
}


    }
}
