using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
	public class TimetableSlot
	{
        public Teacher assignedTeacher { get; set; }
        public Subject assignedSubject { get; set; }
        public Room assignedRoom { get; set; }
        public Schoolclass assignedSchoolclass { get; set; }

        public int day { get; set; }
        public int hour { get; set; }



        public TimetableSlot(Teacher assignedTeacher, Subject assignedSubject, Room assignedRoom, Schoolclass assignedSchoolclass, int day, int hour)
        {
            this.assignedTeacher = assignedTeacher;
            this.assignedSubject = assignedSubject;
            this.assignedRoom = assignedRoom;
            this.assignedSchoolclass = assignedSchoolclass;
            this.day = day;
            this.hour = hour;
        }
        public TimetableSlot Clone()
        {
        return new TimetableSlot(
        this.assignedTeacher,
        this.assignedSubject,
        this.assignedRoom,
        this.assignedSchoolclass,
        this.day,
        this.hour
        );
        }
        public TimetableSlot()
        { }
    }
}