using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        public static int intSelKey = 0;
        public static List<Subject> SubjectList = new List<Subject>();
        public static List<Teacher> TeacherList = new List<Teacher>();
        public static List<Student> StudentList = new List<Student>();
        public static List<Classroom> ClassroomList = new List<Classroom>();
        public static List<Section> SectionList = new List<Section>();
        internal static List<DailySched> DailySchedList = new List<DailySched>();

        static void Main(string[] args)
        {
            Populate.PopulateAll();
            Menu();
            //EnrollSubj_Menu();
            //foreach (Subject a in ObjectRetriever.getStudent(1).SubjectsEnrolled)
            //{
            //    Console.WriteLine("\n" + a.strSubjectCode);
            //}
            Console.ReadKey();
        }

        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n==================================================================");
                Console.WriteLine("\tMain Menu");
                Console.WriteLine("==================================================================");
                Console.WriteLine("1 - Create Menu (Student, Teacher, Classroom, Section, Subject)");
                Console.WriteLine("2 - Edit/Set Menu");
                Console.WriteLine("3 - View Menu");
                Console.WriteLine("4 - Quit");
                Console.WriteLine("==================================================================");
                Console.Write("\nEnter option: ");
                while (!int.TryParse(Console.ReadLine(), out intSelKey))
                { Console.Write("\nEnter option: "); }

                switch (intSelKey)
                {
                    case 1: CreateMenu(); intSelKey = 0; break;
                    case 2: SetMenu(); intSelKey = 0; break;
                    case 3: ViewMenu(); intSelKey = 0; break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            } while (intSelKey != 3);
        }

        public static void CreateMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n==================================================================");
                Console.WriteLine("\tCreate Menu");
                Console.WriteLine("==================================================================");
                Console.WriteLine("1 - Create Teacher");
                Console.WriteLine("2 - Create Student");
                Console.WriteLine("3 - Create Subject");
                Console.WriteLine("4 - Create Section");
                Console.WriteLine("5 - Create Classroom");
                Console.WriteLine("6 - Main Menu");
                Console.Write("\nEnter option: ");

                while (!int.TryParse(Console.ReadLine(), out intSelKey))
                { Console.Write("\nEnter option: "); }
                switch (intSelKey)
                {
                    case 1: Teacher.CreateTeacher(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to Create Menu...");
                        Console.ReadKey();
                        Program.CreateMenu(); break;
                    case 2: Student.CreateStudent(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to Create Menu...");
                        Console.ReadKey();
                        Program.CreateMenu(); break;
                    case 3: Subject.CreateSubject(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to Create Menu...");
                        Console.ReadKey();
                        Program.CreateMenu(); break;
                    case 4: Section.CreateSection(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to Create Menu...");
                        Console.ReadKey();
                        Program.CreateMenu(); break;
                    case 5: Classroom.CreateClassroom(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to Create Menu...");
                        Console.ReadKey();
                        Program.CreateMenu(); break;
                    case 6:
                        Menu();
                        break;
                    default: break;
                }
            } while (intSelKey != 3);
        }
        public static void SetMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n==================================================================");
                Console.WriteLine("\tEdit/Set Menu");
                Console.WriteLine("==================================================================");
                Console.WriteLine("1 - Enroll Student to a Subject");
                Console.WriteLine("2 - Main Menu");
                Console.WriteLine("==================================================================");
                Console.Write("\nEnter option: ");
                while (!int.TryParse(Console.ReadLine(), out intSelKey))
                { Console.Write("\nEnter option: "); }

                switch (intSelKey)
                {
                    case 1: Subject.getSections(); intSelKey = 0; break;
                    case 2:
                        Menu();
                        break;
                    default: break;
                }
            } while (intSelKey != 3);
        }

        public static void ViewMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n==================================================================");
                Console.WriteLine("\tView Menu");
                Console.WriteLine("==================================================================");
                Console.WriteLine("1 - View All Schedules");
                Console.WriteLine("2 - View Schedule of Specific Teacher");
                Console.WriteLine("3 - View Schedule of Specific Student");
                Console.WriteLine("4 - View Schedule of Specific Classroom");
                Console.WriteLine("5 - View List of Students");
                Console.WriteLine("6 - View List of Teachers");
                Console.WriteLine("7 - View List of Subjects");
                Console.WriteLine("8 - View List of Classroom");
                Console.WriteLine("9 - Main Menu");
                Console.WriteLine("==================================================================");
                Console.Write("\nEnter option: ");
                while (!int.TryParse(Console.ReadLine(), out intSelKey))
                { Console.Write("\nEnter option: "); }

                switch (intSelKey)
                {
                    case 1: ObjectRetriever.DisplaySectionList(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to View Menu...");
                        Console.ReadKey();
                        Program.ViewMenu();
                        break;
                    case 2: Teacher.getTeacherSched(); intSelKey = 0; break;
                    case 3: Student.getStudentSched(); intSelKey = 0; break;
                    case 4: Classroom.getClassroomSched(); intSelKey = 0; break;
                    case 5: ObjectRetriever.DisplayStudentList(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to View Menu...");
                        Console.ReadKey();
                        Program.ViewMenu(); break;
                    case 6: ObjectRetriever.DisplayTeacherList(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to View Menu...");
                        Console.ReadKey();
                        Program.ViewMenu(); break;
                    case 7: ObjectRetriever.DisplaySubjectList(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to View Menu...");
                        Console.ReadKey();
                        Program.ViewMenu(); break;
                    case 8: ObjectRetriever.DisplayClassroomList(); intSelKey = 0;
                        Console.Write("\n\nPress any key to continue to View Menu...");
                        Console.ReadKey();
                        Program.ViewMenu(); break;
                    case 9:
                        Menu();
                        break;
                    default: break;
                }
            } while (intSelKey != 3);
        }

        private static void CreateSubject()
        {
            throw new NotImplementedException();
        }

        private static void CreateTeacher()
        {
            throw new NotImplementedException();
        }
    }
}
