using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace School
{
    public class Student : Person
    {
        public static int intStudentId;
        public int intStudent_Id { get; private set; }
        public bool isStudentEnrolled { get; set; }
        private List<Subject> _SubjectsEnrolled;

        public List<Subject> SubjectsEnrolled
        {
            get { return _SubjectsEnrolled; }
            set { _SubjectsEnrolled = value; }
        }
        public Student(bool isStudentEnrolled, string PersonType, string FName, string MName, string LName, int Age, string Address,
            string City, string Province, string Country, string PostalCode, string PhoneNumber, List<Subject> SubjectsEnrolled) :
            base(PersonType, FName, MName, LName, Age, Address, City, Province, Country, PostalCode, PhoneNumber)
        {
            intStudent_Id = Interlocked.Increment(ref intStudentId);
            this.intStudent_Id = intStudent_Id;
            this.isStudentEnrolled = isStudentEnrolled;
            this.strPersonType = PersonType;
            this.strFName = FName;
            this.strMName = MName;
            this.strLName = LName;
            this.intAge = Age;
            this.strAddress = Address;
            this.strCity = City;
            this.strProvince = Province;
            this.strCountry = Country;
            this.strPhoneNumber = PhoneNumber;
            this.SubjectsEnrolled = new List<Subject>(5);
        }

        public static void CreateStudent()
        {
            Console.Write(" Enter student's First Name: ");
            string strFname = Console.ReadLine();
            try
            {
                while (strFname == "")
                {
                    Console.WriteLine("\n First name is required.");
                    Console.Write("\n Enter student's First Name: ");
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
            Console.Write(" Enter student's Middle Initial: ");
            string strMI = Console.ReadLine();
            Console.Write(" Enter student's Last Name: ");
            string strLname = Console.ReadLine();
            try
            {
                while (strLname == "")
                {
                    Console.WriteLine("\n Last name is required.");
                    Console.Write("\n Enter student's Last Name: ");
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
            Console.Write(" Enter student's Age: ");
            int intAge = 0;
            try
            {
                while (int.TryParse(Console.ReadLine(), out intAge) == false)
                {
                    Console.WriteLine("\n Age must be numerical.");
                    Console.Write("\n Enter student's Age: ");
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
            Console.Write(" Enter student's Address: ");
            string strAddress = Console.ReadLine();
            try
            {
                while (strLname == "")
                {
                    Console.WriteLine("\n Address is required.");
                    Console.Write("\n Enter student's Address: ");
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
            Console.Write(" Enter City: ");
            string strCity = Console.ReadLine();
            Console.Write(" Enter Province: ");
            string strProvince = Console.ReadLine();
            Console.Write(" Enter Country: ");
            string strCountry = Console.ReadLine();
            Console.Write(" Enter Postal Code: ");
            string strPostalCode = Console.ReadLine();
            try
            {
                Program.StudentList.Add(new Student(true, "Student", strFname, strMI, strLname, intAge, strAddress, strCity,
                    strProvince, strCountry, strPostalCode, "0", null));
                Console.Write("  Student successfully added!");
            }
            catch (Exception e)
            {
            }
        }

        public static bool EnrollSubject(int student_id, int section_id)
        {
            Student focusedStudent = ObjectRetriever.getStudent(student_id);
            if (focusedStudent._SubjectsEnrolled.Count() == 5)
            {
                Console.WriteLine("Student can only have 5 subjects.");
                return false;
            }
            else
            {
                focusedStudent._SubjectsEnrolled.Add(ObjectRetriever.getSubject(ObjectRetriever.getSection(section_id).Subject.intSubject_Id));
                return true;                
            }
            //Console.WriteLine("\nStudent is enrolled in the following Subjects:" + focusedStudent._SubjectsEnrolled.Count());
            //foreach (Subject c in focusedStudent._SubjectsEnrolled)
            //{
            //    Console.WriteLine(c.strSubjectCode);
            //}
        }

        internal static void getStudentSched()
        {
            int studentid = 0;
            Console.Write("\n Student id: ");
            while (!int.TryParse(Console.ReadLine(), out studentid))
            {
                Console.Write("\n Student id invalid. \n Enter valid student id: ");
            }
            if (studentid <= Program.StudentList.Count)
            {
                ObjectRetriever.DisplayStudentSpecificSched(studentid);
            }
            else
            {
                Console.Write("\n Student id specified not found. Enter a valid id.");
                Console.Write("\n");
                getStudentSched();
            }
        }
    }
}