using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Person
    {
        public string strPersonType { get; set; }
        public string strFName { get; set; }
        public string strLName { get; set; }
        public string strMName { get; set; }
        public int intAge { get; set; }
        public string strAddress { get; set; }
        public string strCity { get; set; }
        public string strProvince { get; set; }
        public string strCountry { get; set; }
        public string strPostalCode { get; set; }
        public string strPhoneNumber { get; set; }

        public Person(string PersonType, string FName, string MName, string LName, int Age, string Address, string City, 
            string Province, string Country, string PostalCode, string PhoneNumber)
        {
            this.strPersonType = PersonType;
            this.strFName = FName;
            this.strMName = MName;
            this.strLName = LName;
            this.intAge = Age;
            this.strAddress = Address;
            this.strCity = City;
            this.strProvince = Province;
            this.strCountry = Country;
            this.strPostalCode = PostalCode;
            this.strPhoneNumber = PhoneNumber;
        }
    }
}
