using System;
using System.Collections.Generic;
using System.Threading;

namespace School
{
    public class Classroom
    {
        public static int intClassroomId;
        public int intClassroom_Id { get; private set; }
        public string strBldg { get; set; }
        public int intFloor { get; set; }
        public string strAddress { get; set; }
        private List<Section> _SectionsListed;

        public List<Section> SectionsListed
        {
            get { return _SectionsListed; }
            set { _SectionsListed = value; }
        }

        public Classroom(string bldg, int floor, List<Section> SectionsListed)
        {
            intClassroom_Id = Interlocked.Increment(ref intClassroomId);
            this.intClassroom_Id = intClassroom_Id;
            this.strBldg = bldg;
            this.intFloor = floor;
            this.strAddress = bldg + "-" + floor + "-" + intClassroomId;
            this.SectionsListed = new List<Section>(5);
        }
        public static void CreateClassroom()
        {
            Console.Write("Enter building where classroom is located: ");
            string bldg = Console.ReadLine();
            Console.Write("Enter what floor classroom is located: ");
            int floor = 0;
            int.TryParse(Console.ReadLine(), out floor);
            try
            {
                Program.ClassroomList.Add(new Classroom(bldg, floor, null));
                Console.Write("  Classroom successfully added!");
            }
            catch(Exception e)
            {

            }
        }

        internal static void getClassroomSched()
        {
            int classroom_id = 0;
            Console.Write("\n Classroom id: ");
            while (!int.TryParse(Console.ReadLine(), out classroom_id))
            {
                Console.Write("\n Classroom id invalid. \n Enter valid classroom id: ");
            }
            if (classroom_id <= Program.ClassroomList.Count)
            {
                ObjectRetriever.DisplayClassroomSpecificSched(classroom_id);
            }
            else
            {
                Console.Write("\n Classroom id specified not found. Enter a valid id.");
                Console.Write("\n");
                getClassroomSched();
            }
        }

        internal static void setSubjectClassroom(int subjectId, int classroomId)
        {
            Classroom focusedClassroom;
            int counter = 0;
            foreach (Section cs in Program.SectionList)
            {
                if (cs.Classroom.intClassroom_Id == classroomId)
                {
                    focusedClassroom = cs.Classroom;
                    counter++;
                }
            }
            if(counter == 5)
            {
                Console.WriteLine("A classroom can only have 5 subjects.");
            }
            else
            {
                Console.Write("\nClassroom id: ");
                int Classroom_id = classroomId;
                int.TryParse(Console.ReadLine(), out Classroom_id);
                Console.Write("Teacher id: ");
                int Faculty_id = 0;
                int.TryParse(Console.ReadLine(), out Faculty_id);
                Console.Write("Subject id: ");
                int Subject_id = 0;
                int.TryParse(Console.ReadLine(), out Subject_id);
                Console.Write("Scheduled Time: ");
                Console.Write("\n  1 - 08:00 to 10:00 AM ");
                Console.Write("\n  2 - 10:00 to 12:00 NN ");
                Console.Write("\n  3 - 12:00 to 02:00 PM ");
                Console.Write("\n  4 - 02:00 to 04:00 PM ");
                Console.Write("\n  5 - 04:00 to 06:00 PM ");
                Console.Write("\nSchedule: ");
                int sectionTime = 0; int.TryParse(Console.ReadLine(), out sectionTime);
                string Section_time = "";
                switch (sectionTime)
                {
                    case 1: Section_time = "08:00 to 10:00 AM"; break;
                    case 2: Section_time = "10:00 to 12:00 NN"; break;
                    case 3: Section_time = "12:00 to 02:00 PM"; break;
                    case 4: Section_time = "02:00 to 04:00 PM"; break;
                    case 5: Section_time = "04:00 to 06:00 PM"; break;
                }

                Classroom newroom = ObjectRetriever.getClassroom(Classroom_id);
                Teacher newteacher = ObjectRetriever.getTeacher(Faculty_id);
                Subject newsubject = ObjectRetriever.getSubject(Subject_id);
                List<Student> EnrolledStudents = new List<Student>(40);
                DailySched newdailysched;
                if (newroom == null || newteacher == null || newsubject == null)
                {
                    if (newroom == null) { Console.WriteLine("Classroom doens't exist."); }
                    if (newteacher == null) { Console.WriteLine("Teacher doens't exist."); }
                    if (newsubject == null) { Console.WriteLine("Subject doens't exist."); }
                    Console.WriteLine("Please recheck directory list of Classrooms, Teachers and Subjects.");
                    Program.Menu();
                }
                else
                {
                    try
                    {
                        Program.SectionList.Add(new Section(newsubject, newteacher, newroom, null, EnrolledStudents));
                        Console.WriteLine("Section successfully added!");
                    }
                    catch (Exception e)
                    { }
                    Program.Menu();
                }
            }

        }
    }
}