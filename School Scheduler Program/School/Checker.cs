using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Checker
    {
        private static void ValueChecker(string thisString)
        {
        }

        private static bool isClassroomBooked(int Classroom_id)
        {
            ObjectRetriever.getClassroom(Classroom_id);
            return false;
        }
    }
}
