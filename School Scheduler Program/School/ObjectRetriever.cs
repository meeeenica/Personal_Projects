using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class ObjectRetriever
    {
        public static Classroom getClassroom(int Classroom_id)
        {
            foreach (Classroom cs in Program.ClassroomList)
            {
                if (cs.intClassroom_Id == Classroom_id)
                { return cs; }
            }
            return null;
        }

        public static Teacher getTeacher(int Faculty_id)
        {
            foreach (Teacher tchr in Program.TeacherList)
            {
                if (tchr.intFaculty_Id == Faculty_id)
                { return tchr; }
            }
            return null;
        }

        public static Subject getSubject(int Subject_id)
        {
            foreach (Subject subjct in Program.SubjectList)
            {
                if (subjct.intSubject_Id == Subject_id)
                { return subjct; }
            }
            return null;
        }
        public static Subject getSubject(string Subject_code)
        {
            foreach (Subject subjct in Program.SubjectList)
            {
                if (subjct.strSubjectCode== Subject_code)
                { return subjct; }
            }
            return null;
        }

        internal static Student getStudent(int Student_id)
        {
            foreach (Student studnt in Program.StudentList)
            {
                if (studnt.intStudent_Id == Student_id)
                { return studnt; }
            }
            return null;
        }

        internal static Section getSection(int Section_id)
        {
            foreach (Section section in Program.SectionList)
            {
                if (section.intSecId == Section_id)
                { return section; }
            }
            return null;
        }

        internal static int getSectionsForSubject(int subj_id)
        {
            List<Section> SubjSect = getSectionsOfSubject(subj_id);
            if (SubjSect.Count() < 1)
            {
                Console.Write("\n  No available schedule.");
                Console.Write("\n  Press any key to return to Edit/Set Menu.");
            }
            else
            {
                Console.Write("\n  Below are the section schedules for the " + getSubject(subj_id).strSubjectName + " subject:\n");
                //Console.Write(SubjSect.Count());
                foreach (Section cs in SubjSect)
                {
                    if (cs.Subject.intSubject_Id == subj_id)
                    {
                        if (cs.StudentsEnrolled.Count() < 40)
                        {
                            Console.WriteLine("\n  Section id: " + cs.intSecId + "\n  Teacher: " + cs.Teacher.strFName + " " + cs.Teacher.strLName
                                + "\n  Classroom: " + cs.Classroom.strAddress + "\n  Subject: " + cs.Subject.strSubjectName
                                + "\n  Time: " + cs.SchedTime.weekday + " " + cs.SchedTime.StartTime + " " + cs.SchedTime.StartAMPM
                                    + " - " + cs.SchedTime.EndTime + " " + cs.SchedTime.EndAMPM
                                + "\n  No. of Students enrolled: " + cs.StudentsEnrolled.Count());
                        }
                    }
                }
            }
            return SubjSect.Count();
        }

        private static List<Section> getSectionsOfSubject(int subj_id)
        {
            List<Section> matchedSection = new List<Section>();
            foreach(Section s in Program.SectionList)
            {
                if(s.Subject.intSubject_Id == subj_id)
                {
                    matchedSection.Add(s);
                }
            }
            return matchedSection;
        }

        internal static void DisplayTeacherList()
        {
            Console.Write("\nList of Teachers:");
            if (Program.TeacherList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Teacher tchr in Program.TeacherList)
                {
                    Console.Write("\n  Teacher id: " + tchr.intFaculty_Id + "\t\tName: " + tchr.strFName + " " + tchr.strLName);
                }
                //Console.Write("\nTeacher id: ");
            }
        }

        internal static void displayTeacherAvailable(string dayOfWeek, int strtTime, Subject subject)
        {
            List<Teacher> occupiedTeachers = new List<Teacher>();
            List<Teacher> availablesTeachers = new List<Teacher>();
            occupiedTeachers = isTeacherAvailable(dayOfWeek, strtTime, subject.SubjectDuration);
            foreach (Teacher c in Program.TeacherList)
            {
                if (checkTeacherMatch(c, occupiedTeachers) == false)
                {
                    if (getTeacherSpecificSched(c.intFaculty_Id) < 20)
                    {
                        Console.Write("\n  Teacher id: " + c.intFaculty_Id + "\tName: " + c.strFName + " " + c.strLName);
                    }
                }
            }
        }

        private static bool checkTeacherMatch(Teacher c, List<Teacher> occupiedTeachers)
        {
            foreach (Teacher oc in occupiedTeachers)
            {
                if (c == oc)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<Teacher> isTeacherAvailable(string dayOfWeek, int strtTime, int subjectDuration)
        {
            bool isOccupied = false;
            List<Teacher> occupiedTeachers = new List<Teacher>();
            foreach (Section s in Program.SectionList)
            {
                if (s.SchedTime.weekday == dayOfWeek && (s.SchedTime.StartTime >= strtTime &&
                    s.SchedTime.EndTime <= strtTime + subjectDuration))
                {
                    occupiedTeachers.Add(s.Teacher);
                }
            }
            return occupiedTeachers;
        }

        internal static void displayClassroomAvailable(string day, int strtTime, Subject subject)
        {
            List<Classroom> occupiedRooms = new List<Classroom>();
            List<Classroom> availableRooms = new List<Classroom>();
            occupiedRooms = isClassroomAvailable(day, strtTime, subject.SubjectDuration);
            foreach (Classroom c in Program.ClassroomList)
            {
                if (checkRoomMatch(c, occupiedRooms) == false)
                {
                    if (getClassroomSpecificSched(c.intClassroom_Id).Item2 < 5 || getClassroomSpecificSched(c.intClassroom_Id).Item1 < 20)
                    {
                        Console.Write("\n  Classroom id: " + c.intClassroom_Id + "\tLocation: " + c.strAddress);
                    }
                }
            }
        }

        private static bool checkRoomMatch(Classroom c, List<Classroom> occupiedRooms)
        {
            foreach (Classroom oc in occupiedRooms)
            {
                if (c == oc)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<Classroom> isClassroomAvailable(string day, int strtTime, int subjectDuration)
        {
            bool isOccupied = false;
            List<Classroom> occupiedRooms = new List<Classroom>();
            foreach(Section s in Program.SectionList)
                {
                    if(s.SchedTime.weekday == day && (s.SchedTime.StartTime >= strtTime ||
                        s.SchedTime.EndTime<= strtTime+subjectDuration))
                    {
                        occupiedRooms.Add(s.Classroom);
                    }
                }
            return occupiedRooms;
        }

        internal static void displayStudentAvailable(string day, int strtTime, Subject subject)
        {
            List<Student> occupiedStudents = new List<Student>();
            List<Student> availableStudents = new List<Student>();
            occupiedStudents = isStudentAvailable(day, strtTime, subject.SubjectDuration);
            foreach (Student c in Program.StudentList)
            {
                if (checkStudentMatch(c, occupiedStudents) == false)
                {
                    if (getStudentSpecificSched(c.intStudent_Id).Item2 < 5 || getStudentSpecificSched(c.intStudent_Id).Item1 < 20)
                    {
                        Console.Write("\n  Student id: " + c.intStudent_Id 
                            + "\tName: " + c.strFName + " " + c.strLName);
                    }
                }
            }
        }

        private static List<Student> isStudentAvailable(string day, int strtTime, int subjectDuration)
        {
            bool isOccupied = false;
            List<Student> occupiedStudents = new List<Student>();
            foreach (Section s in Program.SectionList)
            {
                if (s.SchedTime.weekday == day && (s.SchedTime.StartTime >= strtTime &&
                    s.SchedTime.EndTime <= strtTime + subjectDuration))
                {
                    foreach (Student d in s.StudentsEnrolled)
                    {
                        occupiedStudents.Add(d);
                    }
                }
            }
            return occupiedStudents;
        }

        private static bool checkStudentMatch(Student c, List<Student> occupiedStudents)
        {
            foreach (Student oc in occupiedStudents)
            {
                if (c == oc)
                {
                    return true;
                }
            }
            return false;
        }
        internal static void DisplayStudentList()
        {
            Console.Write("\nList of Students:");
            if (Program.StudentList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Student student in Program.StudentList)
                {
                    Console.Write("\n  Student id: " + student.intStudent_Id + "\t\tName: " + student.strFName + " " + student.strLName);
                }
            }
        }

        internal static List<DailySched> getAvailableSched()
        {
            throw new NotImplementedException();
        }

        internal static void DisplayClassroomList()
        {
            Console.Write("\nList of Classrooms:");
            if (Program.ClassroomList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Classroom cs in Program.ClassroomList)
                {
                    Console.Write("\n  Classroom id: " + cs.intClassroom_Id + "\tLocation: " + cs.strAddress);
                }
                //Console.Write("\nClassroom id: ");
            }
        }

        internal static void DisplaySubjectList()
        {
            Console.Write("\n  List of Subjects:");
            if (Program.SubjectList.Count() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Subject subj in Program.SubjectList)
                {
                    Console.Write("\n  Subject id: " + subj.intSubject_Id + "\t\tSubject: " + subj.strSubjectName);
                }
                //Console.Write("\n\nSubject id: ");
            }
        }

        internal static void DisplaySectionList()
        {
            Console.Write("\nList of Sections:");
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    Console.Write("\n\n  Section id: " + cs.intSecId + "\n  Teacher: " + cs.Teacher.strFName + " " + cs.Teacher.strLName
                        + "\n  Classroom: " + cs.Classroom.strAddress + "\n  Subject: " + cs.Subject.strSubjectName
                        + "\n  Time: " + cs.SchedTime.weekday + " " + cs.SchedTime.StartTime + " " +cs.SchedTime.StartAMPM
                        + " - " + cs.SchedTime.EndTime + " " + cs.SchedTime.EndAMPM
                        + "\n  Total Students: " + cs.StudentsEnrolled.Count());
                }
            }
        }

        internal static void DisplayTeacherSpecificSched(int teacher_id)
        {
            Console.WriteLine("\n  Teacher "+ getTeacher(teacher_id).strFName+" "+ getTeacher(teacher_id).strLName + " Schedule :");
            int hrtaught = 0;
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    if (cs.Teacher.intFaculty_Id == teacher_id)
                    {
                        Console.WriteLine("\n  Section id: " + cs.intSecId + "\n  Teacher: " + cs.Teacher.strFName + " " + cs.Teacher.strLName
                            + "\n  Classroom: " + cs.Classroom.strAddress + "\n  Subject: " + cs.Subject.strSubjectName
                            + "\n  Time: " + cs.SchedTime.weekday + " " + cs.SchedTime.StartTime + " " + cs.SchedTime.StartAMPM
                        + " - " + cs.SchedTime.EndTime + " " + cs.SchedTime.EndAMPM);
                        hrtaught = hrtaught + cs.Subject.SubjectDuration;
                    }
                }
                Console.WriteLine("\n  Total hrs of teaching: " + hrtaught);
            }

            Console.Write("\nPress any key to continue to View Menu...");
            Console.ReadKey();
            Program.ViewMenu();
        }
        internal static int getTeacherSpecificSched(int teacher_id)
        {
            int hrtaught = 0;
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    if (cs.Teacher.intFaculty_Id == teacher_id)
                    {
                        hrtaught = hrtaught + cs.Subject.SubjectDuration;
                    }
                }
            }
            return hrtaught;
        }

        internal static void DisplayStudentSpecificSched(int studentid)
        {
            Console.WriteLine("\n  Student " + getStudent(studentid).strFName + " " + getStudent(studentid).strLName + " Schedule :");
            int hrStudy = 0;
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    foreach (Student student in cs.StudentsEnrolled)
                    {
                        if (student.intStudent_Id == studentid)
                        {
                            Console.WriteLine("\n  Section id: " + cs.intSecId + "\n  Teacher: " + cs.Teacher.strFName + " " + cs.Teacher.strLName
                                + "\n  Classroom: " + cs.Classroom.strAddress + "\n  Subject: " + cs.Subject.strSubjectName
                                + "\n  Time: " + cs.SchedTime.weekday + " " + cs.SchedTime.StartTime + " " + cs.SchedTime.StartAMPM
                        + " - " + cs.SchedTime.EndTime + " " + cs.SchedTime.EndAMPM);
                            hrStudy = cs.Subject.SubjectDuration + hrStudy;
                        }
                    }
                }
                Console.WriteLine("\n  Total hrs of classes: " + hrStudy);
            }

            Console.Write("\nPress any key to continue to View Menu...");
            Console.ReadKey();
            Program.ViewMenu();
        }
        internal static Tuple<int, int> getStudentSpecificSched(int studentid)
        {
            int hrStudy = 0;
            int classcount = 0;
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("No Students Available");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    foreach (Student student in cs.StudentsEnrolled)
                    {
                        if (student.intStudent_Id == studentid)
                        {
                            hrStudy = cs.Subject.SubjectDuration + hrStudy;
                            classcount++;
                        }
                    }
                }
            }
            return Tuple.Create(hrStudy, classcount);
        }

        internal static void DisplayClassroomSpecificSched(int classroom_id)
        {
            Console.WriteLine("\n  Classroom " + getClassroom(classroom_id).strAddress + " Schedule :");
            int hrUsed = 0;
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    if (cs.Classroom.intClassroom_Id == classroom_id)
                    {
                        Console.WriteLine("\n  Section id: " + cs.intSecId + "\n  Teacher: " + cs.Teacher.strFName + " " + cs.Teacher.strLName
                            + "\n  Classroom: " + cs.Classroom.strAddress + "\n  Subject: " + cs.Subject.strSubjectName
                            + "\n  Time: " + cs.SchedTime.weekday + " " + cs.SchedTime.StartTime + " " + cs.SchedTime.StartAMPM
                        + " - " + cs.SchedTime.EndTime + " " + cs.SchedTime.EndAMPM);
                        hrUsed = cs.Subject.SubjectDuration + hrUsed;
                    }
                }
                Console.WriteLine("\n  Total hrs of room use: " + hrUsed);
            }
            Console.Write("\nPress any key to continue to View Menu...");
            Console.ReadKey();
            Program.ViewMenu();
        }
        internal static Tuple<int,int> getClassroomSpecificSched(int classroom_id)
        {
            int hrUsed = 0;
            int classcount = 0;
            if (Program.SectionList.Count() == 0)
            {
                Console.WriteLine("No Classrooms Available");
            }
            else
            {
                foreach (Section cs in Program.SectionList)
                {
                    if (cs.Classroom.intClassroom_Id == classroom_id)
                    {
                        hrUsed = cs.Subject.SubjectDuration + hrUsed;
                        classcount++;
                    }
                }
            }
            return Tuple.Create(hrUsed, classcount);
        }
    }
}
