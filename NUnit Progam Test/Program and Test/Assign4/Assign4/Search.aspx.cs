using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign4
{
    public partial class Search : System.Web.UI.Page
    {
        public static DataClasses1DataContext db1 = new DataClasses1DataContext();
        private bool manuStat = false,modelStat = false, yrStat= false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var availableModels = (from carTbl in db1.Cars
                                      select carTbl.Model).Distinct().ToList();
                List<String> availModels = availableModels.ToList();
                models.DataSource = availableModels;
                models.DataBind();
                //manu.Text = "Car Make";
                //models.Items.Insert(-1, new ListItem("Car Model", "Car Model"));
                //models.Text = "Car Model";
                var availableCars = (from carTbl in db1.Cars
                                     where carTbl.Model == (models.SelectedValue.ToString())
                                     && carTbl.CarMake == (manu.SelectedValue.ToString())
                                     select carTbl).ToList();
                gvCars.DataSource = availableCars;
                gvCars.DataBind();
            }
            if(manuStat==true)
            {
                ListItem a = new ListItem();
                a.Value = "Select One";
                a.Text = "Select One";
                models.Items.Add(a);
                ddlYear.Items.Add(a);
                manuStat = false;
            }
            if (modelStat == true)
            {
                ListItem a = new ListItem();
                a.Value = "Select One";
                a.Text = "Select One";
                ddlYear.Items.Add(a);
                modelStat = false;
            }
        }

        protected void modelsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCars.Visible = true;
            var availableModels = (from carTbl in db1.Cars
                                  where carTbl.CarMake == (manu.SelectedValue.ToString())
                                   select carTbl.Model).Distinct().ToList();
            models.DataSource = availableModels;
            models.DataBind();
            var availableCars = (from carTbl in db1.Cars
                                 where carTbl.CarMake == (manu.SelectedValue.ToString())
                                 select carTbl).ToList();
            gvCars.DataSource = availableCars;
            gvCars.DataBind();
            manuStat = true;
        }

        protected void models_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCars.Visible = true;
            var availableModels = (from carTbl in db1.Cars
                                   where carTbl.Model == (models.SelectedValue.ToString())
                                   && carTbl.CarMake == (manu.SelectedValue.ToString())
                                   select carTbl.Year).Distinct().ToList();
            ddlYear.DataSource = availableModels;
            ddlYear.DataBind();
            var availableCars = (from carTbl in db1.Cars
                                 where carTbl.Model == (models.SelectedValue.ToString())
                                 && carTbl.CarMake == (manu.SelectedValue.ToString())
                                 select carTbl).ToList();
            gvCars.DataSource = availableCars;
            gvCars.DataBind();
            modelStat = true;
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCars.Visible = true;
                var availableCars = (from carTbl in db1.Cars
                                       where carTbl.Model == (models.SelectedValue.ToString())
                                       && carTbl.CarMake == (manu.SelectedValue.ToString())
                                       && carTbl.Year == int.Parse(ddlYear.SelectedItem.Text)
                                       select carTbl).ToList();
                gvCars.DataSource = availableCars;
                gvCars.DataBind();
            Console.Write(ddlYear.SelectedValue);
        }

        protected void gvCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCars.SelectedRow;
            Response.Redirect("~/ViewPosting.aspx?ID="
                    + HttpUtility.UrlEncode(row.Cells[0].Text)
                    + "/"
                    + HttpUtility.UrlEncode(row.Cells[1].Text)
                    + "/"
                    + HttpUtility.UrlEncode(row.Cells[2].Text)
                    + "/"
                    + HttpUtility.UrlEncode(row.Cells[3].Text));
        }
    }
}