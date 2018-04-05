using System;
using System.Collections.Generic;
using System.Threading;

namespace School
{
    public class Teacher : Person
    {
        public static int intFacultyId;
        public int intFaculty_Id { get; private set; }
        public bool isActive { get; set; }
        private List<Subject> _SubjectsTaught;
        public List<Subject> SubjectsTaught
        {
            get { return _SubjectsTaught; }
            set { _SubjectsTaught = value; }
        }
        public Teacher(bool isActive, string PersonType, string FName, string MName, string LName, int Age, string Address, 
            string City, string Province, string PostalCode, string PhoneNumber, string EmailAddress, List<Subject> SubjectsTaught) : 
            base(PersonType, FName, MName, LName, Age, Address, City, Province, PostalCode, PhoneNumber, EmailAddress)
        {
            intFaculty_Id = Interlocked.Increment(ref intFacultyId);
            this.intFaculty_Id = intFaculty_Id;
            this.isActive = isActive;
            this.strPersonType = PersonType;
            this.strFName = FName;
            this.strMName = MName;
            this.strLName = LName;
            this.intAge = Age;
            this.strAddress = Address;
            this.strCity = City;
            this.strProvince = Province;
            this.strPhoneNumber = PhoneNumber;
            this.SubjectsTaught = new List<Subject>(5);
        }

        internal static void CreateTeacher()
        {
            Console.Write(" Enter First Name: ");
            string strFname = Console.ReadLine();
            try
            {
                while (strFname == "")
                {
                    Console.WriteLine("\n First name is required.");
                    Console.Write("\n Enter First Name: ");
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
            Console.Write(" Enter Middle Initial: ");
            string strMI = Console.ReadLine();
            Console.Write(" Enter Last Name: ");
            string strLname = Console.ReadLine();
            try
            {
                while (strLname == "")
                {
                    Console.WriteLine("\n Last name is required.");
                    Console.Write("\n Enter Last Name: ");
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
            Console.Write(" Enter Age: ");
            int intAge = 0;
            try
            {
                while (int.TryParse(Console.ReadLine(), out intAge) == false)
                {
                    Console.WriteLine("\n Age must be numerical.");
                    Console.Write("\n Enter Age: ");
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
            Console.Write(" Enter Address: ");
            string strAddress = Console.ReadLine();
            try
            {
                while (strLname == "")
                {
                    Console.WriteLine("\n Address is required.");
                    Console.Write("\n Enter Address: ");
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
                Program.TeacherList.Add(new Teacher(true, "Teacher", strFname, strMI, strLname, intAge, strAddress, strCity, 
                    strProvince, strCountry, strPostalCode, "0", null));
                Console.Write("  Teacher successfully added!");
            }
            catch (Exception e)
            {
            }
        }

        internal static void getTeacherSched()
        {
            int tchrid = 0;
            Console.Write("\nTeacher id: ");
            while (!int.TryParse(Console.ReadLine(), out tchrid))
            {
                Console.Write("\n Teacher id invalid. \n Enter valid teacher id: ");
            }
            if (tchrid <= Program.TeacherList.Count)
            {
                ObjectRetriever.DisplayTeacherSpecificSched(tchrid);
            }
            else
            {
                Console.Write("\n Teacher id specified not found. Enter a valid id.");
                Console.Write("\n");
                getTeacherSched();
            }
        }
    }
}