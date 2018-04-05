using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Populate
    {
        public static void PopulateAll()
        {
            PopulateStudent(Program.StudentList);
            PopulateTeacher(Program.TeacherList);
            PopulateClassrooms(Program.ClassroomList);
            PopulateSubject(Program.SubjectList);
            PopulateSection(Program.SectionList);
            PopulateDailySched(Program.DailySchedList);
            PopulateStudenttoSection();
            PopulateStudentSubject();
        }

        private static List<DailySched> PopulateDailySched(List<DailySched> DailyScheds)
        {
            List<DailySched> testSDailyScheds = new List<DailySched>();
            testSDailyScheds = DailyScheds;
            testSDailyScheds.Add(new DailySched("Monday", 0, null, null, 0));
            return testSDailyScheds;
        }

        private static List<Student> PopulateStudent(List<Student> Students)
        {
            List<Student> testStudents = new List<Student>();
            testStudents = Students;
            testStudents.Add(new Student(true, "Student", "Lea", "M", "Belo", 12, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testStudents.Add(new Student(true, "Student", "Yaroslav", "A", "Handabura", 12, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testStudents.Add(new Student(true, "Student", "Nuchjarin", "B", "Phromsorn", 12, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testStudents.Add(new Student(true, "Student", "Jinny", "J", "Zhao", 12, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testStudents.Add(new Student(true, "Student", "Bob", "O", "Joe", 12, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            return testStudents;
        }

        private static List<Teacher> PopulateTeacher(List<Teacher> Teachers)
        {
            List<Teacher> testTeachers = new List<Teacher>();
            testTeachers = Teachers;
            testTeachers.Add(new Teacher(true, "Teacher", "Ey", "A", "Alpha", 30, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testTeachers.Add(new Teacher(true, "Teacher", "Bee", "B", "Bravo", 33, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testTeachers.Add(new Teacher(true, "Teacher", "Cee", "C", "Charlie", 30, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testTeachers.Add(new Teacher(true, "Teacher", "Di", "D", "Delta", 32, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            testTeachers.Add(new Teacher(true, "Teacher", "Eee", "E", "Echo", 31, "Kitchener", "Kitchener", "ON", "Canada", "N2P 2N5", "0", null));
            return testTeachers;
        }

        private  static List<Classroom> PopulateClassrooms(List<Classroom> Classrooms)
        {
            List<Classroom> testClassrooms = new List<Classroom>();
            testClassrooms = Classrooms;
            testClassrooms.Add(new Classroom("A", 1,null));
            testClassrooms.Add(new Classroom("A", 1, null));
            testClassrooms.Add(new Classroom("A", 2, null));
            testClassrooms.Add(new Classroom("A", 2, null));
            testClassrooms.Add(new Classroom("A", 3, null));
            return testClassrooms;
        }
        private static List<Subject> PopulateSubject(List<Subject> Subjects)
        {
            List<Subject> testSubjects = new List<Subject>();
            testSubjects = Subjects;
            testSubjects.Add(new Subject("Mathematics", "MATH", 2));
            testSubjects.Add(new Subject("English", "ENG", 2));
            testSubjects.Add(new Subject("Science", "SCI", 2));
            testSubjects.Add(new Subject("History", "HIS", 2));
            testSubjects.Add(new Subject("Computer", "COMP", 2));
            return testSubjects;
        }
        private static List<Section> PopulateSection(List<Section> Sections)
        {
            List<Section> testSection = new List<Section>();
            testSection = Sections;
            testSection.Add(new Section(ObjectRetriever.getSubject(1), 
                ObjectRetriever.getTeacher(1), 
                ObjectRetriever.getClassroom(1), 
                new DailySched("Mon", 8, "AM", "AM" ,2), null));
            testSection.Add(new Section(ObjectRetriever.getSubject(2), 
                ObjectRetriever.getTeacher(1), 
                ObjectRetriever.getClassroom(1),
                new DailySched("Tue", 8, "AM", "AM", 2), null));
            testSection.Add(new Section(ObjectRetriever.getSubject(2), 
                ObjectRetriever.getTeacher(2), 
                ObjectRetriever.getClassroom(3),
                new DailySched("Wed", 8, "AM", "AM", 2), null));
            testSection.Add(new Section(ObjectRetriever.getSubject(1), 
                ObjectRetriever.getTeacher(3), 
                ObjectRetriever.getClassroom(2),
                new DailySched("Thu", 8, "AM", "AM", 2), null));
            testSection.Add(new Section(ObjectRetriever.getSubject(2), 
                ObjectRetriever.getTeacher(4), 
                ObjectRetriever.getClassroom(5),
                new DailySched("Fri", 8, "AM", "AM", 2), null));
            return testSection;
        }

        private static void PopulateStudenttoSection()
        {
            Student.EnrollSubject(1, 1);
            Section.AddStudenttoSection(1, 1, ObjectRetriever.getSubject(ObjectRetriever.getSection(1).intSecId).intSubject_Id);
            Student.EnrollSubject(1, 2);
            Section.AddStudenttoSection(2, 1, ObjectRetriever.getSubject(ObjectRetriever.getSection(2).intSecId).intSubject_Id);
            Student.EnrollSubject(2, 1);
            Section.AddStudenttoSection(1, 2, ObjectRetriever.getSubject(ObjectRetriever.getSection(1).intSecId).intSubject_Id);
            Student.EnrollSubject(2, 2);
            Section.AddStudenttoSection(2, 2, ObjectRetriever.getSubject(ObjectRetriever.getSection(2).intSecId).intSubject_Id);
            Student.EnrollSubject(3, 3);
            Section.AddStudenttoSection(3, 3, ObjectRetriever.getSubject(ObjectRetriever.getSection(3).intSecId).intSubject_Id);
        }
        private static void PopulateStudentSubject()
        {
            Student.EnrollSubject(1, 1);
            Student.EnrollSubject(1, 2);
            Student.EnrollSubject(2, 1);
            Student.EnrollSubject(2, 2);
            Student.EnrollSubject(3, 3);
            Student.EnrollSubject(3, 4);
            Student.EnrollSubject(4, 3);
            Student.EnrollSubject(4, 4);
            Student.EnrollSubject(5, 1);
            Student.EnrollSubject(5, 2);
        }
    }
}
