using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Room
    {
        public static List<Room> AllRooms = new List<Room>();

        private string _abbreviation;
        public string Abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }

        public Room(string abbreviation)
        {
            abbreviation = (abbreviation ?? "").Trim();

            if (abbreviation.Length > 4)
                abbreviation = abbreviation.Substring(0, 4);
            else if (abbreviation.Length < 4)
                abbreviation = abbreviation.PadLeft(4, ' ');

            Abbreviation = abbreviation;
            AllRooms.Add(this);
        }
    }
}
