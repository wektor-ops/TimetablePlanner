using System;
using System.Collections.Generic;
using System.Linq;
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
                    
                        MStudent()
                break;
                case 2:
                    MTeacher()


                 break;
                case 3:
                    MSchoolclass()
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

            }
        }
        public void Studentnew()
        {
            Console.WriteLine("Please Enter fistname of student");
            string studentfirstname = Console.ReadLine();
            Console.WriteLine("Please Enter lastname of student");
            string studentlastname = Console.ReadLine();
            new Student(studentfirstname, studentlastname);

        }
        
        public void StudentShow() 
        {
            foreach (Student s in Student.Allstudents)
                Console.WriteLine(s.Firstname + " " + s.Lastname + " - " + s.Class.Abbreviation);

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

            }
        }
        public void Teachershow() 
        {
            foreach (Teacher t in Teacher.AllTeachers)
                Console.WriteLine(t.Firstname + " " + t.Lastname);
        }
        public void Teachernew() 
        {
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
                public string Daysoffwork;
               
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
                        
                }
                while(Daysoffwork != "X")
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
                Console.WriteLine(sc. + " ");
            break;
        case 0:

            break;
    }
}



                   
        }
    }
}
