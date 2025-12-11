using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetablePlanner
{
    internal interface IScheduleEvaluator
    {
        int Evaluate(List<Schoolclass> currentPlan);
    }
}
