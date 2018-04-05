using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PictureFeed
{
    public partial class ImageFeed : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
            {
                string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/UploadedFiles"));
                List<String> images = new List<string>(filesindirectory.Count());

                foreach (string item in filesindirectory.Reverse())
                {
                    StreamReader sr = File.OpenText((Server.MapPath("~/Messages/") + (System.IO.Path.GetFileNameWithoutExtension(item) + "_Msg.txt")));
                    images.Add("<hr /><table style=\"margin:auto; display:block;\"><tr><td>Message: </td><td><p  style=\"margin:20px; \" >" + sr.ReadLine() + "</p></td></tr></table><br />");
                    images.Add(String.Format("~/UploadedFiles/{0}", System.IO.Path.GetFileName(item)));
                }
                if (filesindirectory.Count() < 1)
                {
                    //Response.Write("<br /><h2 style=\"text - indent:10px; \">No items found!</h2>");
                    headNoItem.Visible = true;
                    brNoItem.Visible = true;
                }
                else
                {
                    headNoItem.Visible = false;
                    brNoItem.Visible = false;
                }
                RepeaterImages.DataSource = images;
                RepeaterImages.DataBind();
            }

            private int a = 0;
            protected void RepeaterImages_ItemCreated(object sender, RepeaterItemEventArgs e)
            {
                if (a % 2 == 0)
                {
                    e.Item.FindControl("Image").Visible = false;
                    a++;
                }
                else
                {
                    e.Item.FindControl("Mes").Visible = false;
                    a++;
                }
                //Response.Write(e);
            }

            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                Response.Redirect("Default.aspx", false);
            }
        }
    }