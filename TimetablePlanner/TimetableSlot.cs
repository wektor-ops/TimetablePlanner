using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
	internal class TimetableSlot
	{
        public Teacher assigntTeacher { get; set; }
        public Subject assigntSubject { get; set; }
        public Room assigntRoom { get; set; }
        public Schoolclass assigntSchoolclass { get; set; }

        public TimetableSlot(Teacher assigntTeacher, Subject assigntSubject, Room assigntRoom, Schoolclass assigntSchoolclass)
        {
            this.assigntTeacher = assigntTeacher;
            this.assigntSubject = assigntSubject;
            this.assigntRoom = assigntRoom;
            this.assigntSchoolclass = assigntSchoolclass;
        }

    }
}