using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign4
{
    public partial class AddCar : System.Web.UI.Page
    {
        public static DataClasses1DataContext db1 = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                var P = from prov in db1.Cities
                        where prov.City1 == city.Text
                        select prov.Province;

                db1.AddCarEntry(fname.Text, lname.Text, address.Text, city.Text, P.FirstOrDefault().ToString(), phone.Text, email.Text, carmake.Text,
              model.Text, int.Parse(year.Text), decimal.Parse(price.Text));

                var savedcar = db1.SearchCar(carmake.Text, model.Text, int.Parse(year.Text),
                    decimal.Parse(price.Text), decimal.Parse(price.Text)).FirstOrDefault();
                Response.Redirect("~/ViewPosting.aspx?ID="
                    + HttpUtility.UrlEncode(savedcar.ID.ToString())
                    +"/"
                    + HttpUtility.UrlEncode(savedcar.CarMake.ToString())
                    +"/"
                    + HttpUtility.UrlEncode(savedcar.Model.ToString())
                    +"/"
                    + HttpUtility.UrlEncode(savedcar.Year.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}