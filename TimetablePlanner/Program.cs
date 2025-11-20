using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[1] Stundenplan generieren\n[2] Lehrperson hinzufügen\n[3] Schüler hinzufügen\n[4] Raum hinzufügen\n[5] Fach hinzufügen");
            string Auswahl = Console.ReadLine();

            switch (Auswahl)
            {
                case 1:

                    Console.Write("Was bist du?\n\n [LP] Lehreperson\n [S] Schüler/in\n");
                    string input = Console.ReadLine()?.ToLower();

                    if (input == "lp")
                    {
                        Console.Write("Wie lautet ihr Name?\n");
                        string LP = Console.ReadLine();
                        string gesuchterName = LP;
                        // ich bruch Liste zum witer mache

                        //string gesuchterName = LP;
                        //bool schuelerGefunden = schuelerListe.Any(s => s.Name == gesuchterName);
                        // if (schuelerGefunden{Console.WriteLine($"Lehrer '{gesuchterName}' wurde gefunden.");}else{ Console.WriteLine($'Lehrer '{gesuchterName}' nicht gefunden.");}


                        // jetzt bruch ich das wo Jan am mache esch
                    }
                    else
                    {
                        Console.Write("Wie lautet ihr Name?\n");
                        string S = Console.ReadLine();
                        string gesuchterName = S;

                        //dane au Liste

                        //string gesuchterName = "S";
                        //bool schuelerGefunden = schuelerListe.Any(s => s.Name == gesuchterName);
                        // if (schuelerGefunden{Console.WriteLine($"✅ Schüler '{gesuchterName}' wurde gefunden.");}else{ Console.WriteLine($"❌ Schüler '{gesuchterName}' nicht gefunden.");}


                        //burche au das wo Jan am mache esch 

                        Console.Write("Stundenplan \n ");
                    }
            }


            Console.Write("Was bist du?\n\n [LP] Lehreperson\n [S] Schüler/in\n");
            string input = Console.ReadLine()?.ToLower();

            if (input == "lp")
            {
                Console.Write("Wie lautet ihr Name?\n");
                string LP = Console.ReadLine();
                string gesuchterName = LP;
                // ich bruch Liste zum witer mache

                //string gesuchterName = LP;
                //bool schuelerGefunden = schuelerListe.Any(s => s.Name == gesuchterName);
                // if (schuelerGefunden{Console.WriteLine($"Lehrer '{gesuchterName}' wurde gefunden.");}else{ Console.WriteLine($'Lehrer '{gesuchterName}' nicht gefunden.");}
                
                
                // jetzt bruch ich das wo Jan am mache esch
            }
            else
            {
                Console.Write("Wie lautet ihr Name?\n");
                string S = Console.ReadLine();
                string gesuchterName = S;
               
                //dane au Liste

                //string gesuchterName = "S";
                //bool schuelerGefunden = schuelerListe.Any(s => s.Name == gesuchterName);
                // if (schuelerGefunden{Console.WriteLine($"✅ Schüler '{gesuchterName}' wurde gefunden.");}else{ Console.WriteLine($"❌ Schüler '{gesuchterName}' nicht gefunden.");}


                //burche au das wo Jan am mache esch 

                 Console.Write("Stundenplan \n ");
            }
            break;





        }
    }
}
