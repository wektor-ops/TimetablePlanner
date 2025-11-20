using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Timetable
    {
        public void OutputStundenplan() 
        {
            Console.WriteLine("╔════════╦════════════════╦════════════════╦════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("║  Zeit  ║       Mo       ║       Di       ║       Mi       ║       Do       ║       Fr       ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 08:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 09:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 10:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 11:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 12:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 13:00  ║                ║                ║                ║                ║                ║");
            Console.WriteLine("║        ║                ║                ║                ║                ║                ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 14:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 15:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 16:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 17:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╠════════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣");
            Console.WriteLine("║ 18:00  ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║   Ma   Gok     ║");
            Console.WriteLine("║        ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║ D24a   R102    ║");
            Console.WriteLine("╚════════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝");

        }
            



    }
}
