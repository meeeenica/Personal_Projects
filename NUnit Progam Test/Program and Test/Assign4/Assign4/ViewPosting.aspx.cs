using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign4
{
    public partial class ViewPosting : System.Web.UI.Page
    {
        public static DataClasses1DataContext db1 = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            String ID = Request.QueryString["ID"];
            String Maker = Request.QueryString["Maker"];
            String Model = Request.QueryString["Model"];
            String Year = Request.QueryString["Year"];

            string[] words = ID.Split('/');
            //foreach (string word in words)
            //{
            //    Console.WriteLine(word);
            //}
            var carSel = (from c in db1.Cars
                          where c.ID == int.Parse(words[0])
                          select c).FirstOrDefault();

            lblmake.Text = words[1];
            lblmodel.Text = words[2];
            lblyear.Text = words[3];
            lblprice.Text = "$ " + carSel.Price.ToString();
            lblfname.Text = carSel.Firstname.ToString();
            lbllname.Text = carSel.Lastname.ToString();
            lbladdress.Text = carSel.Address.ToString();
            lblcity.Text = carSel.City.ToString() + ", " + carSel.Province.ToString();
            lblPhone.Text = carSel.Phone.ToString();
            lblEmail.Text = carSel.Email.ToString();
            Label1.Text= "http://www.jdpower.com/cars/" + words[1] + "/" + words[2] + "/" + words[3];
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            ownerDiv.Visible = true;
        }
    }
}