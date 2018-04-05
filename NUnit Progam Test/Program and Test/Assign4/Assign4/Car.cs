using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assign4
{
    public class Cars
    {
        public  string OwnerFirstname { get; set; }
        public  string OwnerLastname { get; set; }
        public  int entryID { get; set; }
        public  string AddressLocation { get; set; }
        public  string CityLocation { get; set; }
        public  string ProvinceLocation { get; set; }
        public  string OwnerPhone { get; set; }
        public  string OwnerEmail { get; set; }
        public  string CarMaker { get; set; }
        public  string CarModel { get; set; }
        public  int CarYear { get; set; }
        public  decimal PostingPrice { get; set; }

        public Cars(string OwnerFirstname, string OwnerLastname, int entryID, string AddressLocation,
            string CityLocation, string ProvinceLocation, string OwnerPhone,
            string OwnerEmail, string CarMaker, string CarModel, int CarYear, decimal PostingPrice)
        {
            this.OwnerFirstname = OwnerFirstname;
            this.OwnerLastname = OwnerLastname;
            this.entryID = entryID;
            this.AddressLocation = AddressLocation;
            this.CityLocation = CityLocation;
            this.ProvinceLocation = ProvinceLocation;
            this.OwnerPhone = OwnerPhone;
            this.OwnerEmail = OwnerEmail;
            this.CarMaker = CarMaker;
            this.CarModel = CarModel;
            this.CarYear = CarYear;
            this.PostingPrice = PostingPrice;
        }
    }
}