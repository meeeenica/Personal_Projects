using System;
using System.Collections.Generic;
using System.Threading;

namespace School
{
    public class Section
    {
        public static int intSectionId;
        public int intSecId { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public DailySched SchedTime { get; set; }
        private List<Student> _StudentsEnrolled;

        public List<Student> StudentsEnrolled
        {
            get { return _StudentsEnrolled; }
            set { _StudentsEnrolled = value; }
        }

        public Section(Subject Subject, Teacher Teacher, Classroom Classroom, DailySched SchedTime, 
            List<Student> StudentsEnrolled)
        {
            intSecId = Interlocked.Increment(ref intSectionId);
            this.Subject = Subject;
            this.Teacher = Teacher;
            this.Classroom = Classroom;
            this.SchedTime = SchedTime;
            this._StudentsEnrolled = new List<Student>(40);
        }
        public static void CreateSection()
        {
            Console.Clear();
            Console.WriteLine("\n\n==================================================================");
            Console.WriteLine("\tCreate Section");
            Console.WriteLine("==================================================================");
            Console.Write("\n Available subjects to be scheduled: \n  ");
            ObjectRetriever.DisplaySubjectList();
            int Subject_id = 0;
            Console.Write("\n\n Which Subject would you like to schedule? \n Enter subject id: ");
            while (!int.TryParse(Console.ReadLine(), out Subject_id) || Subject_id > Program.SubjectList.Count)
            {
                Console.Write("\n Subject id invalid. \n Enter subject id: ");
            }

            Console.Write("\n When would you like to schedule it? (Mon, Tue, Wed, Thu, Fri) \n Enter day of week: ");
            string dayOfWeek = Console.ReadLine();
            bool DayOfWeekChecker = false;
            switch (dayOfWeek.ToUpper())
            {
                case "MON": DayOfWeekChecker = true; break;
                case "TUE": DayOfWeekChecker = true; break;
                case "WED": DayOfWeekChecker = true; break;
                case "THU": DayOfWeekChecker = true; break;
                case "FRI": DayOfWeekChecker = true; break;
            }
            while (DayOfWeekChecker == false || (dayOfWeek == null && dayOfWeek == ""))
            {
                Console.Write("\n Invalid day! \n When would you like to schedule it? (Mon, Tue, Wed, Thu, Fri) "
                    + "\n Enter day of week: ");
                dayOfWeek = Console.ReadLine();
                switch (dayOfWeek.ToUpper())
                {
                    case "MON": DayOfWeekChecker = true; break;
                    case "TUE": DayOfWeekChecker = true; break;
                    case "WED": DayOfWeekChecker = true; break;
                    case "THU": DayOfWeekChecker = true; break;
                    case "FRI": DayOfWeekChecker = true; break;
                }
            }

            Console.Write("\n What time would you like to schedule it?"
                + "\n Enter start time of subject class (military hr format): ");
            int strtTime = 0;
            while (!int.TryParse(Console.ReadLine(), out strtTime) || strtTime < 8)
            {
                Console.Write("\n Invalid time!"
                    + "\n Enter start time of subject class (military hr format): ");
            }

            Console.Write("\n Below are the classrooms available during your specified time:");
            ObjectRetriever.displayClassroomAvailable(dayOfWeek, strtTime, ObjectRetriever.getSubject(Subject_id));
            Console.Write("\n\n Id of classroom to schedule: ");
            int Classroom_id = 0;
            while (!int.TryParse(Console.ReadLine(), out Classroom_id) || Classroom_id > Program.ClassroomList.Count)
            {
                Console.Write("\n Invalid classroom id!"
                    + "\n Enter id of available classroom: ");
            }

            Console.Write("\n Below are the teachers available:");
            ObjectRetriever.displayTeacherAvailable(dayOfWeek, strtTime, ObjectRetriever.getSubject(Subject_id));
            Console.Write("\n\n Id of teacher who will handle class: ");
            int Faculty_id = 0;
            while (!int.TryParse(Console.ReadLine(), out Faculty_id) || Faculty_id > Program.TeacherList.Count)
            {
                Console.Write("\n Invalid teacher id!"
                    + "\n Enter id of available teacher: ");
            }

            Classroom newroom = ObjectRetriever.getClassroom(Classroom_id);
            Teacher newteacher = ObjectRetriever.getTeacher(Faculty_id);
            Subject newsubject = ObjectRetriever.getSubject(Subject_id);
            int hr_strtTime = Time.FormatTime(strtTime).Item1;
            string AMPM = Time.FormatTime(strtTime).Item2;
            int hr_endime = Time.FormatTime(strtTime + newsubject.SubjectDuration).Item1;
            string PMAM = Time.FormatTime(strtTime + newsubject.SubjectDuration).Item2;
            DailySched newDailySched = new DailySched(dayOfWeek, hr_strtTime, AMPM, PMAM, newsubject.SubjectDuration);
            List<Student> EnrolledStudents = new List<Student>(40);
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
                    Program.SectionList.Add(new Section(newsubject, newteacher, newroom, newDailySched, EnrolledStudents));
                    Console.Write("  Section successfully added!");
                }
                catch(Exception e)
                { }
            }
        }

        internal static void ViewSchedule()
        {
            throw new NotImplementedException();
        }

        internal static void SetSchedule()
        {
            throw new NotImplementedException();
        }

        public static void AddStudenttoSection(int section_id, int student_id, int subject_id)
        {
            Section focusedSection = ObjectRetriever.getSection(section_id);
            if (focusedSection._StudentsEnrolled.Count == 40)
            {
                Console.WriteLine("A section can only have 40 students");
            }
            else
            {
                //Student.EnrollSubject(student_id, subject_id);
                focusedSection._StudentsEnrolled.Add(ObjectRetriever.getStudent(student_id));
            }
        }
    }
}