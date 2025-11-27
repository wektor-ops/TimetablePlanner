using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    public class Room
    {
        public static List<Room> AllRooms = new List<Room>();
        [JsonIgnore]
        public TimetableSlot[,] RoomPlan { get; set; }

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
            RoomPlan = new TimetableSlot[Timetable.Days, Timetable.Hours];
        }
        public Room()
        { }
    }
}
