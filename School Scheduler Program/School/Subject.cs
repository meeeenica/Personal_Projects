using System;
using System.Threading;

namespace School
{
    public class Subject
    {
        public static int intSubjectId;
        public int intSubject_Id { get; set; }
        public string strSubjectName { get; set; }
        public string strSubjectCode { get; set; }
        public int SubjectDuration { get; set; }

        public Subject(string strSubjectName, string strSubjectCode, int SubjectDuration)
        {
            intSubject_Id = Interlocked.Increment(ref intSubjectId);
            this.intSubject_Id = intSubject_Id;
            this.strSubjectName = strSubjectName;
            this.strSubjectCode = strSubjectCode;
            this.SubjectDuration = SubjectDuration;
        }

        internal static void CreateSubject()
        {
            Console.Write(" Enter Subject Name: ");
            string strSubjectName = Console.ReadLine();
            try
            {
                while (strSubjectName == "")
                {
                    Console.WriteLine("\n Subject name is required.");
                    Console.Write("\n Enter Subject Name: ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Value. Press any key to return to main menu...");
                if (Console.ReadKey() != null)
                {
                    Console.Clear();
                    Program.Menu();
                }
            }
            Console.Write(" Enter Subject Code: ");
            string strSubjCode= Console.ReadLine();
            try
            {
                while (strSubjCode == "")
                {
                    Console.WriteLine("\n Subject Code is required.");
                    Console.Write("\n Enter Subject Code: ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Value. Press any key to return to main menu...");
                if (Console.ReadKey() != null)
                {
                    Console.Clear();
                    Program.Menu();
                }
            }
            Console.Write("\n Enter Subject duration (in hrs): ");
            int subjectDuration = 0;
                while (!int.TryParse(Console.ReadLine(), out subjectDuration))
                {
                    Console.Write("\n Invalid Entry.");
                    Console.Write("\n Enter Subject duration (in hrs): ");
                }
            try
            {
                Program.SubjectList.Add(new Subject(strSubjectName, strSubjCode, subjectDuration));
                Console.Write("  Subject successfully added!");
            }
            catch (Exception e)
            {
            }
        }

        internal static void getSections()
        {
            int subj_id = 0;
            ObjectRetriever.DisplaySubjectList();
            Console.Write("\n\n  Which Subject would you like to schedule? \n  Enter subject id: ");
            while (!int.TryParse(Console.ReadLine(), out subj_id))
            {
                Console.Write("\n  Subject id invalid. \n  Enter subject id: ");
            }
            if (ObjectRetriever.getSectionsForSubject(subj_id) < 1)
            { 
                Console.ReadKey();
                Program.SetMenu();
            }
            else
            {
                int sect_id;
                Console.Write("\n  Which section would you like to enroll student to? \n  Enter section id: ");
                while (!int.TryParse(Console.ReadLine(), out sect_id))
                {
                    Console.Write("\n  Section id invalid. \n  Enter section id: ");
                }
                int student_id;
                ObjectRetriever.displayStudentAvailable(ObjectRetriever.getSection(sect_id).SchedTime.weekday,
                    ObjectRetriever.getSection(sect_id).SchedTime.StartTime, ObjectRetriever.getSection(sect_id).Subject);

                Console.Write("\n  Which student would you enroll? \n  Enter student id: ");
                while (!int.TryParse(Console.ReadLine(), out student_id))
                {
                    Console.Write("\n  Student id invalid. \n  Enter student id: ");
                }
                ObjectRetriever.getSection(sect_id).StudentsEnrolled.Add(ObjectRetriever.getStudent(student_id));
                Console.Write("\n  Student success fully enrolled to " + ObjectRetriever.getSection(sect_id).Subject.strSubjectName);
            }
            Console.Write("\n\nPress any key to continue to Edit/Set Menu...");
            Console.ReadKey();
            Program.SetMenu();
        }
        public static void EnrollSubj_Menu()
        {

        }
    }
}