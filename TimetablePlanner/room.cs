using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal class Room
    {
       
        private String _abbreviation;
        public string Abbreviation;
        {
            get { return _abbreviation}
            set;
        }

        public Room(string abbreviation) 
        {
            Abbreviation = abbreviation;
         
        }
    }
}
