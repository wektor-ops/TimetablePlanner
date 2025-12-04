using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal interface IScheduleExporter
    {
        void ExportStudentPlan(Schoolclass schoolclass);
        void ExportTeacherPlan(Teacher teacher);
        void ExportRoomPlan(Room room);
    }
}
